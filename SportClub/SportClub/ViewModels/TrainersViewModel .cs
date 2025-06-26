
using SportClub.Models;
using SportClub.Interfaces;

namespace SportClub.ViewModels
{
	public class TrainersViewModel : BaseEntityViewModel<Trainer>
	{
		public TrainersViewModel(IRepository<Trainer> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var t = new Trainer
			{
				FullName = "Новый тренер",
				PhoneNum = "+70000000001",
				SpecializationId = 6,
				DateOfAcceptance = DateTime.UtcNow
			};
			await _repo.AddAsync(t);
			await LoadAsync();
		}
	}
}
