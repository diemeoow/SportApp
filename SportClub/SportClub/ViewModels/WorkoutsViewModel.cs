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
		public WorkoutsViewModel(IRepository<Workout> repo) : base(repo) { }

		public override async Task AddAsync()
		{
			var w = new Workout
			{
				Name = "Новое занятие",
				TypeOfWorkoutId = 1,
				TrainerId = 1,
				RoomId = 1,
				Date = DateTime.Today,
				Time = TimeSpan.FromHours(10),
				Duration = 60
			};
			await _repo.AddAsync(w);
			await LoadAsync();
		}
	}
}
