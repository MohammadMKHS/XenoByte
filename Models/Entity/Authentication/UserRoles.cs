using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace XenoByte.Models.Entity.Authentication
{
    public class UserRoles
    {
        [Key] 
        public int Id { get; set; }

        // Foreign Keys
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
