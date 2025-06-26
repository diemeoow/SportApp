using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class WorkoutGroupViewModel : BaseEntityViewModel<WorkoutGroup>
	{
		public WorkoutGroupViewModel(IRepository<WorkoutGroup> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new WorkoutGroup
			{
				Name = "Новая группа",
				TypeOfWorkoutId = 1,
				TrainerId = 1
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
