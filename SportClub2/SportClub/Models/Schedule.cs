using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("schedule")]
    public class Schedule
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("workout_id")]
        public int? WorkoutId { get; set; }

        [Column("day_of_week")]
        public string DayOfWeek { get; set; }

        [Column("time")]
        public TimeSpan? Time { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }
    }
}
