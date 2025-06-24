using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class Room
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Capacity { get; set; }

		// Тип помещения
		public int RoomTypeId { get; set; }
		public RoomType RoomType { get; set; }

		public ICollection<Workout> Workouts { get; set; }
		public ICollection<Equipment> EquipmentItems { get; set; }
	}
}
