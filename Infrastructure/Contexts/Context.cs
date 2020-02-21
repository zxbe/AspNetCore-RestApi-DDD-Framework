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
        }
    }
}