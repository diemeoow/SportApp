using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class Equipment
	{
		public int Id { get; set; }
		public string Name { get; set; }

		// Тип оборудования
		public int EquipmentTypeId { get; set; }
		public EquipmentType EquipmentType { get; set; }

		// Помещение
		public int RoomId { get; set; }
		public Room Room { get; set; }

		// Состояние
		public int EquipmentConditionId { get; set; }
		public EquipmentCondition EquipmentCondition { get; set; }
	}
}
