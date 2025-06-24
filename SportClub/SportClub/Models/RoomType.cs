using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class RoomType
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Room> Rooms { get; set; }
	}
}
