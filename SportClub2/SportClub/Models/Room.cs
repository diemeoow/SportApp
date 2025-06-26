using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("room")]
	public class Room
	{
		[Key, Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("capacity")]
		public int? Capacity { get; set; }

		[Column("room_type_id")]
		public int? RoomTypeId { get; set; }

		// ← Навигационное свойство
		public RoomType RoomType { get; set; }
	}
}
