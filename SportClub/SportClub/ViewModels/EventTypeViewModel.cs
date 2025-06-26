using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class EventTypeViewModel : BaseEntityViewModel<EventType>
	{
		public EventTypeViewModel(IRepository<EventType> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new EventType { Name = "Новый тип" };
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
