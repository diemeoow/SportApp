using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("event")]
    public class Event
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("type_id")]
        public int? TypeId { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        [Column("room_id")]
        public int? RoomId { get; set; }

        [Column("description")]
        public string Description { get; set; }
        [ForeignKey(nameof(TypeId))]
        public EventType Type { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }
    }
}
