using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("evaluation_event")]
	public class EvaluationEvent
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("event_id")]
		public int? EventId { get; set; }

		[Column("app_user_id")]
		public int? AppUserId { get; set; }

		[Column("appraisal")]
		public int? Appraisal { get; set; }

		[Column("commentary")]
		public string Commentary { get; set; }
	}
}
