using System.ComponentModel.DataAnnotations;
using static HRManagement.Attributes.MinimumAge;

namespace HRManagement.Models
{
    public class ResumeTrackingDetail
    {
        [Key]
        public int ResumeID { get;private set; }
        [Required]
        public string ApplicantName { get; set;}
        [Required]
        public string PhoneNo { get; set;}
        [Required]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Qualification { get; set; }

        [DataType(DataType.DateTime)]
        [MinimumAge(18, ErrorMessage = "Minimum age required is 18 years.")]  
        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string Nationality { get; set; }


        [StringLength(100)]
        [MinLength(3)]
        public string Address { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string ApplyingFor { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? Experience { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? Specialization { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? AreaOfInterest { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        public string? Certifications { get; set; }
    }
}
