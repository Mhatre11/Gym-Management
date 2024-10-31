using System.ComponentModel.DataAnnotations;

namespace Api.Models
{

    public enum MembershipType
    {
        OneMonth,
        ThreeMonths,
        SixMonths,
        OneYear
    }
    public enum MembershipStatus
    {
        Active,
        Inactive,
        Cancelled
    }
    public class Members
    {

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime MembershipStartDate { get; set; }
        public MembershipType MembershipType { get; set; } = MembershipType.OneMonth;
        public MembershipStatus MembershipStatus { get; set; } = MembershipStatus.Active;


    }
}