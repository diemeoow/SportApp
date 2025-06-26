using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class WorkoutsViewModel : BaseEntityViewModel<Workout>
	{
		public WorkoutsViewModel(IRepository<Workout> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var w = new Workout
			{
				Name = "Новое занятие",
				TypeOfWorkoutId = 6,
				TrainerId = 2,
				RoomId = 2,
				Date = DateTime.UtcNow.Date,
				Time = TimeSpan.FromHours(10),
				Duration = 60
			};
			await _repo.AddAsync(w);
			await LoadAsync();
		}
	}
}
