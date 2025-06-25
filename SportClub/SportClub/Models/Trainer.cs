using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("trainer")]
	public class Trainer
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("full_name")]
		public string FullName { get; set; }

		[Column("phone_num")]
		public string PhoneNum { get; set; }

		[Column("trainer_specialization_id")]
		public int SpecializationId { get; set; }

		[ForeignKey(nameof(SpecializationId))]
		public TrainerSpecialization Specialization { get; set; }

		[Column("date_of_acceptance")]
		public DateTime DateOfAcceptance { get; set; }
	}
}
