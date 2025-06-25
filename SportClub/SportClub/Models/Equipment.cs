using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("equipment")]
	public class Equipment
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("type_id")]
		public int EquipmentTypeId { get; set; }

		[ForeignKey(nameof(EquipmentTypeId))]
		public EquipmentType EquipmentType { get; set; }

		// добавить:
		[Column("status_id")]
		public int EquipmentConditionId { get; set; }

		[ForeignKey(nameof(EquipmentConditionId))]
		public EquipmentCondition EquipmentCondition { get; set; }

		[Column("room_id")]
		public int RoomId { get; set; }
		public Room Room { get; set; }
	}
}
