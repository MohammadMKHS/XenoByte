using Microsoft.EntityFrameworkCore;
using XenoByte.Models.Entity.Authentication;
using XenoByte.Models.Entity;

namespace XenoByte.AppManager
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }
        public DbSet<RansomwareReport> RansomwareReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<RansomwareReport>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            // Configure the relationship between RansomwareReport and User
            modelBuilder.Entity<RansomwareReport>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin",CreatedAt = new DateTime(2025, 8, 12) },
                new Role { Id = 2, Name = "User", CreatedAt = new DateTime(2025, 8, 12) }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@example.com",
                    PasswordHash = "klb5gPgOix1Sp9uHVMX+yK3s6Nvylm0qlTZfIk/bcrs=",
                    PasswordSalt = "wJrDwiOhol/FFA72QgOSbg==",
                    CreatedAt = new DateTime(2025, 8, 12)
                }
            );

            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { Id = 1, UserId = 1, RoleId = 1 }
            );
        }
    }
}
