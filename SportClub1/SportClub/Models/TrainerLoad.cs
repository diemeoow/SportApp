using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
