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
				Phone_num = "+70000000000",
				Date_registration = DateTime.Now
			};
			await _repo.AddAsync(c);
			await LoadAsync();
		}
	}
}