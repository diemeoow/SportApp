using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("booking_room")]
	public class BookingRoom
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("room_id")]
		public int? RoomId { get; set; }

		[Column("workout_id")]
		public int? WorkoutId { get; set; }

		[Column("time")]
		public TimeSpan? Time { get; set; }

		[Column("date")]
		public DateTime? Date { get; set; }
	}
}
