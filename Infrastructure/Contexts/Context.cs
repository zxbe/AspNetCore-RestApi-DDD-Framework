using Domain.Authenticate;
using Domain.Code;
using Domain.Token;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public sealed class Context : DbContext
    {
        public Context (DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TokenModel> Token { get; set; }
        public DbSet<CodeModel> Code { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasIndex(b => b.Email)
                .IsUnique();
            modelBuilder.Entity<UserModel>()
                .HasIndex(b => b.Phone)
                .IsUnique();
            modelBuilder.Entity<UserModel>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<UserModel>()
                .Property(b => b.IsActive)
                .HasDefaultValueSql("true");
            modelBuilder.Entity<UserModel>()
                .Property(b => b.NamePatronymic)
                .HasDefaultValueSql("null");
            modelBuilder.Entity<UserModel>()
                .Property(b => b.Phone)
                .HasDefaultValueSql("null");

            modelBuilder.Entity<TokenModel>()
                .HasIndex(b => b.UserId);
            modelBuilder.Entity<TokenModel>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<TokenModel>()
                .Property(b => b.UserAgent)
                .HasDefaultValueSql("null");
            modelBuilder.Entity<TokenModel>()
                .HasOne<UserModel>(g => g.User)
                .WithMany(s => s.Tokens)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CodeModel>()
                .HasIndex(b => b.UserId);
            modelBuilder.Entity<CodeModel>()
                .HasIndex(b => b.Code);
            modelBuilder.Entity<CodeModel>()
                .HasOne<UserModel>(g => g.User)
                .WithMany(s => s.Codes)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}