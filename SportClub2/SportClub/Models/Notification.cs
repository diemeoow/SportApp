using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("notification")]
	public class Notification
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("app_user_id")]
		public int? AppUserId { get; set; }

		[Column("text")]
		public string Text { get; set; }

		[Column("send_date")]
		public DateTime? SendDate { get; set; }
	}
}
