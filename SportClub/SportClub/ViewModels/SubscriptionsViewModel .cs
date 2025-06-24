using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class SubscriptionsViewModel : BaseEntityViewModel<Subscription>
	{
		public SubscriptionsViewModel(IRepository<Subscription> repo) : base(repo) { }

		public override async Task AddAsync()
		{
			var s = new Subscription
			{
				Name = "Новый абонемент",
				Price = 0,
				DurationDays = 30
			};
			await _repo.AddAsync(s);
			await LoadAsync();
		}
	}
}
