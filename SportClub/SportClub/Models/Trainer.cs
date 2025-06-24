using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class Trainer
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string PhoneNum { get; set; }

		// Специализация
		public int SpecializationId { get; set; }
		public TrainerSpecialization TrainerSpecialization { get; set; }

		public DateTime DateOfAcceptance { get; set; }

		public ICollection<Workout> Workouts { get; set; }
	}
}
