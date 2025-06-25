using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
