using System.ComponentModel.DataAnnotations;

namespace XenoByte.Models.ViewModels
{
    public class RansomwareReportViewModel
    {
        [Required(ErrorMessage = "Bitcoin addresses are required")]
        [Display(Name = "Bitcoin addresses")]
        public string BitcoinAddresses { get; set; } = string.Empty;

        [Display(Name = "Family (if known)")]
        public string? Family { get; set; }

        [Display(Name = "How much bitcoin is the ransomware demanding?")]
        public string? Demand { get; set; }

        [Display(Name = "Upload a screenshot of the payment page")]
        public IFormFile? PaymentScreenshot { get; set; }

        [Display(Name = "Upload the ransom note")]
        public IFormFile? RansomNote { get; set; }

        [Display(Name = "Link to source (if public)")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? SourceLink { get; set; }

        [Display(Name = "Any other notes (optional)")]
        public string? Notes { get; set; }

        [Display(Name = "Your email address (optional)")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? ReporterEmail { get; set; }
    }
}