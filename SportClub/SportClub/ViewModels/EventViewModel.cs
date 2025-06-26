using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;

namespace SportClub.ViewModels
{
	public class EventViewModel : BaseEntityViewModel<Event>
	{
		public EventViewModel(IRepository<Event> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new Event
			{
				Name = "Новое событие",
				TypeId = 1,
				Date = DateTime.UtcNow.AddDays(7),
				RoomId = 1,
				Description = "Описание"
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
