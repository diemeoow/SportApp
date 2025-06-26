using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
