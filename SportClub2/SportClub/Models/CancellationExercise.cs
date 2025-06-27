using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("cancellation_exercise")]
    public class CancellationExercise
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("workout_id")]
        public int? WorkoutId { get; set; }

        [Column("reason")]
        public string Reason { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }
    }
}
