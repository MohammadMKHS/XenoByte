using System.ComponentModel.DataAnnotations;

namespace XenoByte.Models.Entity.Authentication
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Password Reset Fields
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }

        // Navigation
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
