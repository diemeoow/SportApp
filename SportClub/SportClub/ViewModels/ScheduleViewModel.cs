using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class ScheduleViewModel : BaseEntityViewModel<Schedule>
	{
		public ScheduleViewModel(IRepository<Schedule> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new Schedule
			{
				WorkoutId = 1,
				DayOfWeek = "Понедельник",
				Time = TimeSpan.FromHours(10)
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}

}
