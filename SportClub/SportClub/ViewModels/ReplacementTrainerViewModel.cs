using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class ReplacementTrainerViewModel : BaseEntityViewModel<ReplacementTrainer>
	{
		public ReplacementTrainerViewModel(IRepository<ReplacementTrainer> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new ReplacementTrainer
			{
				WorkoutId = 1,
				OldTrainerId = 1,
				NewTrainerId = 2
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
