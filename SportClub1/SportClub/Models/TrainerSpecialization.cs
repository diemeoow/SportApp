﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	[Table("trainer_specialization")]
	public class TrainerSpecialization
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string? Name { get; set; }
	}
}
