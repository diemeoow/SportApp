using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SportClub.ViewModels
{
	public class VisitHistoryViewModel : BaseEntityViewModel<VisitHistory>
	{
		public VisitHistoryViewModel(IRepository<VisitHistory> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new VisitHistory
			{
				AppUserId = 1,
				Date = DateTime.UtcNow.Date,
				WorkoutId = 1,
				MarkAttendance = true
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
