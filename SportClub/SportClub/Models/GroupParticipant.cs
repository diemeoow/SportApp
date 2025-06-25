using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("group_participant")]
	public class GroupParticipant
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("workout_group_id")]
		public int? WorkoutGroupId { get; set; }

		[Column("app_user_id")]
		public int? AppUserId { get; set; }
	}
}
