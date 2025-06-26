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
		public SubscriptionsViewModel(IRepository<Subscription> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var s = new Subscription
			{
				Name = "Новый абонемент",
				SubscriptionTypeId = 6,
				DurationDays = 30,                 // колонка deadline_action
				DateStarted = DateTime.UtcNow         // колонка date_started
			};
			await _repo.AddAsync(s);
			await LoadAsync();
		}
	}
}
