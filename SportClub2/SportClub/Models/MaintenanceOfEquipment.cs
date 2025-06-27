using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("maintenance_of_equipment")]
    public class MaintenanceOfEquipment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("equipment_id")]
        public int? EquipmentId { get; set; }

        [Column("date_of_service")]
        public DateTime? DateOfService { get; set; }

        [Column("commentary")]
        public string Commentary { get; set; }
        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; }
    }
}
