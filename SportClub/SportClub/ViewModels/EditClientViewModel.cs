using SportClub.Interfaces;
using SportClub.Models;
using System.Windows.Input;
using SportClub.Infrastructure;
using System.Windows;

namespace SportClub.ViewModels
{
	public class EditClientViewModel : BaseViewModel
	{
		private readonly IRepository<Client> _repo;
		public Client Current { get; }
		public ICommand SaveCommand { get; }

		public EditClientViewModel(IRepository<Client> repo, Client client)
		{
			_repo = repo;
			Current = client;
			SaveCommand = new RelayCommand(async _ =>
			{
				await _repo.UpdateAsync(Current);
				((Window)Application.Current.Windows[Application.Current.Windows.Count - 1]).Close();
			});
		}
	}
}
