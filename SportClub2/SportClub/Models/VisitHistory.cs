using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("visit_history")]
    public class VisitHistory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("app_user_id")]
        public int? AppUserId { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        [Column("workout_id")]
        public int? WorkoutId { get; set; }

        [Column("mark_attendance")]
        public bool? MarkAttendance { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }

    }
}
