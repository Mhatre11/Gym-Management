using System.ComponentModel.DataAnnotations;

namespace Api.Models
{

    public enum EquipmentStatus
    {
        Operational,
        UnderMaintenance,
        OutOfOrder,
        Retired
    }

    public class Equipments
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public DateTime? MaintenanceDate { get; set; }
        [Required]

        public required EquipmentStatus Status { get; set; }
    }
}