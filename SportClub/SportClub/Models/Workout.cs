using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class Workout
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Time { get; set; }
		public int Duration { get; set; }

		// Тип тренировки
		public int TypeOfWorkoutId { get; set; }
		public TypeOfWorkout TypeOfWorkout { get; set; }

		// Тренер
		public int TrainerId { get; set; }
		public Trainer Trainer { get; set; }

		// Помещение
		public int RoomId { get; set; }
		public Room Room { get; set; }
	}
}
