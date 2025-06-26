using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class TrainerLoadViewModel : BaseEntityViewModel<TrainerLoad>
	{
		public TrainerLoadViewModel(IRepository<TrainerLoad> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new TrainerLoad
			{
				TrainerId = 1,
				Date = DateTime.UtcNow.Date,
				NumberOfExercises = 3
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
