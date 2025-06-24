using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class TypeOfWorkout
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsIndividual { get; set; }

		public ICollection<Workout> Workouts { get; set; }
	}
}
