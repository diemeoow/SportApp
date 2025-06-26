using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class HealthIndicatorsViewModel : BaseEntityViewModel<HealthIndicators>
	{
		public HealthIndicatorsViewModel(IRepository<HealthIndicators> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new HealthIndicators
			{
				HealthGroup = "Основная",
				Restrictions = "Нет",
				ValidTo = DateTime.UtcNow.AddYears(1)
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
