using System.ComponentModel.DataAnnotations;

namespace XenoByte.Models.Entity
{
    public class RansomwareReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BitcoinAddresses { get; set; } = string.Empty;

        public string? Family { get; set; }

        public string? Demand { get; set; }

        public string? PaymentScreenshotPath { get; set; }

        public string? RansomNotePath { get; set; }

        public string? SourceLink { get; set; }

        public string? Notes { get; set; }

        public string? ReporterEmail { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Optional: Link to the user who submitted the report (if authenticated)
        public int? UserId { get; set; }
        public Models.Entity.Authentication.User? User { get; set; }
    }
}