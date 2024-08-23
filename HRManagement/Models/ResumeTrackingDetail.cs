using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models
{
    public class ResumeTrackingDetail
    {
        [Key]
        public int ResumeID { get; set; }
        [Required]
        public string ApplicantName { get; set;}
        [Required]
        public string PhoneNo { get; set;}
        [Required]
        public string Qualification { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? Experience { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? Specialization { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? AreaOfInterest { get; set; }
    }
}
