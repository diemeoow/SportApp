using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class RecordToWorkoutViewModel : BaseEntityViewModel<RecordToWorkout>
	{
		public RecordToWorkoutViewModel(IRepository<RecordToWorkout> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new RecordToWorkout
			{
				AppUserId = 1,
				WorkoutId = 1,
				RecordStatusId = 1
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
