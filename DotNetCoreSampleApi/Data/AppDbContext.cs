using DotNetCoreSampleApi.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DotNetCoreSampleApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adding roles in the database
            //modelBuilder.Entity<Role>().HasData
            //(
            //    new Role { RoleId = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
            //    new Role { RoleId = Guid.NewGuid(), Name = "Customer", NormalizedName = "CUSTOMER" }
            //);

            //Setting foreign key behavior while deleting
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Unique key on user name
            //    modelBuilder.Entity<User>()
            //        .HasAlternateKey(u => u.UserName)
            //        .HasName("IX_UserName");
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}