using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        NetBanking,
        Cash
    }
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int MemberID { get; set; }
        [ForeignKey("ID")]
        public required Members Member { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
    }
}