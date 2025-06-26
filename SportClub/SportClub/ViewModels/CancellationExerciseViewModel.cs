using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class CancellationExerciseViewModel : BaseEntityViewModel<CancellationExercise>
	{
		public CancellationExerciseViewModel(IRepository<CancellationExercise> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new CancellationExercise
			{
				Reason = "Технические причины",
				Date = DateTime.UtcNow,
				WorkoutId = 1
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
