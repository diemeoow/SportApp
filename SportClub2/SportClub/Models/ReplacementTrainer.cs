using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("replacement_trainer")]
    public class ReplacementTrainer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("workout_id")]
        public int? WorkoutId { get; set; }

        [Column("old_trainer_id")]
        public int? OldTrainerId { get; set; }

        [Column("new_trainer_id")]
        public int? NewTrainerId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }

        [ForeignKey(nameof(OldTrainerId))]
        public Trainer OldTrainer { get; set; }

        [ForeignKey(nameof(NewTrainerId))]
        public Trainer NewTrainer { get; set; }
    }
}
