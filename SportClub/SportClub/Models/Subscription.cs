using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class Subscription
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int DurationDays { get; set; }

		// Обратная навигация
		public ICollection<Client> Clients { get; set; }
	}
}
