using Microsoft.EntityFrameworkCore;
using XenoByte.Models.Entity.Authentication;

namespace XenoByte.AppManager
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", CreatedAt = DateTime.UtcNow },
                new Role { Id = 2, Name = "User", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@example.com",
                    PasswordHash = "hashed_password", // You should hash this
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { Id = 1, UserId = 1, RoleId = 1 }
            );
        }
    }
}
