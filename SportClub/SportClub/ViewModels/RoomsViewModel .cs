using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class RoomsViewModel : BaseEntityViewModel<Room>
	{
		public RoomsViewModel(IRepository<Room> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var r = new Room
			{
				Name = "Новый зал",
				Capacity = 10,
				RoomTypeId = 6
			};
			await _repo.AddAsync(r);
			await LoadAsync();
		}
	}
}
