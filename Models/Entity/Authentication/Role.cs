using System.ComponentModel.DataAnnotations;

namespace XenoByte.Models.Entity.Authentication
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }  // e.g., "Admin", "User"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<UserRoles> UserRoles { get; set; }

        
    }
}
