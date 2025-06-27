using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("trainer_load")]
    public class TrainerLoad
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("trainer_id")]
        public int? TrainerId { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        [Column("number_of_exercises")]
        public int? NumberOfExercises { get; set; }
        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; }
    }
}
