using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("workout")]
	public class Workout
	{
		[Key, Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("type_of_workout_id")]
		public int? TypeOfWorkoutId { get; set; }

		// ← Навигационное свойство
		public TypeOfWorkout Type { get; set; }

		[Column("trainer_id")]
		public int? TrainerId { get; set; }

		// ← Навигационное свойство
		public Trainer Trainer { get; set; }

		[Column("room_id")]
		public int? RoomId { get; set; }

		// ← Навигационное свойство
		public Room Room { get; set; }

		[Column("date")]
		public DateTime? Date { get; set; }

		[Column("time")]
		public TimeSpan? Time { get; set; }

		[Column("duration")]
		public int? Duration { get; set; }
	}
}
