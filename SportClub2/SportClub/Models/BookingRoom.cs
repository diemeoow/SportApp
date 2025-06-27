using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("booking_room")]
    public class BookingRoom
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("room_id")]
        public int? RoomId { get; set; }

        [Column("workout_id")]
        public int? WorkoutId { get; set; }

        [Column("time")]
        public TimeSpan? Time { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }
    }
}
