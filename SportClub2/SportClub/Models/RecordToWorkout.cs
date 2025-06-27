using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("record_to_workout")]
    public class RecordToWorkout
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("app_user_id")]
        public int? AppUserId { get; set; }

        [Column("workout_id")]
        public int? WorkoutId { get; set; }

        [Column("record_status_id")]
        public int? RecordStatusId { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }

        [ForeignKey(nameof(RecordStatusId))]
        public RecordStatus RecordStatus { get; set; }
    }
}
