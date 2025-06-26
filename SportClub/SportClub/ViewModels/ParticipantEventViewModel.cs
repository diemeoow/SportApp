using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class ParticipantEventViewModel : BaseEntityViewModel<ParticipantEvent>
	{
		public ParticipantEventViewModel(IRepository<ParticipantEvent> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new ParticipantEvent
			{
				EventId = 1,
				AppUserId = 1,
				Result = "Участвовал"
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
