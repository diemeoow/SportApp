using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class BookingRoomViewModel : BaseEntityViewModel<BookingRoom>
	{
		public BookingRoomViewModel(IRepository<BookingRoom> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new BookingRoom
			{
				RoomId = 1,
				WorkoutId = 1,
				Time = TimeSpan.FromHours(10),
				Date = DateTime.UtcNow.Date
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
