using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
	public class Client
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Phone_num { get; set; }
		public DateTime Date_registration { get; set; }

		// Связь с абонементами
		public int? SubscriptionId { get; set; }
		public Subscription Subscription { get; set; }
	}
}
