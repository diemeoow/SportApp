using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("type_of_workout")]
	public class TypeOfWorkout
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("individual")]
		public bool? Individual { get; set; }

		[Column("is_individual")]
		public bool? IsIndividual { get; set; }
	}
}
