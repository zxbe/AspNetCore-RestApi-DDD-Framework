using System;
using System.IO;
using System.Text;
using Api.Scheduler;
using Domain.Authenticate;
using Domain.Code;
using Domain.Token;
using Domain.User;
using Infrastructure.Contexts;
using Infrastructure.Crypto;
using Infrastructure.Email;
using Infrastructure.Repositories.Code;
using Infrastructure.Repositories.Token;
using Infrastructure.Repositories.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Implementations;

namespace Api
{
    public class Startup
    {
        private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        private static readonly string AppSettings =
            string.IsNullOrEmpty(Env) ? "appsettings.json" : $"appsettings.{Env}.json";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            #region DI Service
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile(AppSettings, optional: true, reloadOnChange: false);
            services.AddSingleton(builder.Build());
            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICodeService, CodeService>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddSingleton<CryptoHelper>();
            services.AddSingleton<IHostedService, ScheduleTask>();
            #endregion

            #region DI Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICodeRepository, CodeRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            #endregion
            
            #region DI Infrastructure
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddSingleton(typeof(EmailSender));
            #endregion
            
            services.AddCors();
            services.AddMvc(p => p.EnableEndpointRouting = false);

            var key = Encoding.ASCII.GetBytes(Configuration["AppSettings:Secret"]);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = false
                    };
                });

            var securityScheme = new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                BearerFormat = "Bearer {authToken}",
                Description = "JWT Token",
                Type = SecuritySchemeType.ApiKey
            };
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KPD API", Version = "v1" });
                c.AddSecurityDefinition(
                    "Bearer", securityScheme
                );
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme, Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });
            
            services.AddControllers();
            services.AddDbContext<Context>(options =>
            {
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("DBMigrations")
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // if (env.IsDevelopment())
            // {
            app.UseDeveloperExceptionPage();
            // }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMvc();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KPD v1");
            });
            
            UpdateDatabase(app);

            var logger = loggerFactory.CreateLogger("LoggerInStartup");
            logger.LogInformation($"\n\n{DateTime.Now} | Startup logger was launched");
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<Context>();

            context.Database.Migrate();
        }
    }
}