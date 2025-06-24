
using SportClub.Models;
using SportClub.Interfaces;

namespace SportClub.ViewModels
{
	public class TrainersViewModel : BaseEntityViewModel<Trainer>
	{
		public TrainersViewModel(IRepository<Trainer> repo) : base(repo) { }

		public override async Task AddAsync()
		{
			var t = new Trainer
			{
				FullName = "Новый тренер",
				PhoneNum = "+70000000001",
				DateOfAcceptance = DateTime.Now,
				SpecializationId = 1
			};
			await _repo.AddAsync(t);
			await LoadAsync();
		}
	}
}
