using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("room")]
    public class Room
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("capacity")]
        public int? Capacity { get; set; }

        [Column("room_type_id")]
        public int? RoomTypeId { get; set; }

        // ← Навигационное свойство
        public RoomType RoomType { get; set; }
    }
}
