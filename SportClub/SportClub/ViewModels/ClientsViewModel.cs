using SportClub.Models;
using SportClub.Interfaces;

namespace SportClub.ViewModels
{
	public class ClientsViewModel : BaseEntityViewModel<Client>
	{
		public ClientsViewModel(IRepository<Client> repo) : base(repo) { }

		public override async Task AddAsync()
		{
			var c = new Client
			{
				FullName = "Новый клиент",
				PhoneNum = "+70000000000",          // было Phone_num
				DateRegistration = DateTime.UtcNow     // было Date_registration
			};
			await _repo.AddAsync(c);
			await LoadAsync();
		}
	}
}