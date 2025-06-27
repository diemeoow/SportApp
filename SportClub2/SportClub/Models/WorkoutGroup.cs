using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("workout_group")]
    public class WorkoutGroup
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("type_of_workout_id")]
        public int? TypeOfWorkoutId { get; set; }

        [Column("trainer_id")]
        public int? TrainerId { get; set; }
        [ForeignKey(nameof(TypeOfWorkoutId))]
        public TypeOfWorkout TypeOfWorkout { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; }
    }
}
