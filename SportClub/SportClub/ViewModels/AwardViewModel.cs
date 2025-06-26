using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class AwardViewModel : BaseEntityViewModel<Award>
	{
		public AwardViewModel(IRepository<Award> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new Award
			{
				Name = "Новая награда",
				Place = 1,
				AppUserId = 1,
				EventId = 1
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
