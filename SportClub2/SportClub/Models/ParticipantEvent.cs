using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SportClub.Models
{
	[Table("participant_event")]
	public class ParticipantEvent
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("event_id")]
		public int? EventId { get; set; }

		[Column("app_user_id")]
		public int? AppUserId { get; set; }

		[Column("result")]
		public string Result { get; set; }
	}
}
