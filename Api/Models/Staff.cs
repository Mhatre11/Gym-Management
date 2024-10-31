using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Staff
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [Phone]
        public required string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        public required string Position { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
        public decimal Salary { get; set; }
    }
}