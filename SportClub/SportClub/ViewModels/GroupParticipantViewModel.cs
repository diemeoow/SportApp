using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class GroupParticipantViewModel : BaseEntityViewModel<GroupParticipant>
	{
		public GroupParticipantViewModel(IRepository<GroupParticipant> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new GroupParticipant
			{
				WorkoutGroupId = 1,
				AppUserId = 1
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
