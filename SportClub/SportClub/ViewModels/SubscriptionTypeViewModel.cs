using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace SportClub.ViewModels
{
	public class SubscriptionTypeViewModel : BaseEntityViewModel<SubscriptionType>
	{
		public SubscriptionTypeViewModel(IRepository<SubscriptionType> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new SubscriptionType
			{
				Name = "Новый тип",
				Description = "Описание"
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
