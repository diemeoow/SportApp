using SportClub.Infrastructure;
using SportClub.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClub.ViewModels
{
	public class GenericEntityViewModel<T> : BaseViewModel where T : class, new()
	{
		private readonly IRepository<T> _repo;

		public ObservableCollection<T> Items { get; } = new();
		public ICommand LoadCommand { get; }
		public ICommand AddCommand { get; }
		public ICommand DeleteCommand { get; }
		public ICommand ImportCommand { get; }
		public ICommand ExportCommand { get; }

		public GenericEntityViewModel(IRepository<T> repo)
		{
			_repo = repo;

			LoadCommand = new RelayCommand(async _ => await LoadAsync());
			AddCommand = new RelayCommand(async _ => await AddAsync());
			DeleteCommand = new RelayCommand(async obj => await DeleteAsync(obj as T));
			ImportCommand = new RelayCommand(async _ => { }); // Временно заглушка
			ExportCommand = new RelayCommand(async _ => { }); // Временно заглушка
		}

		private async Task LoadAsync()
		{
			Items.Clear();
			foreach (var item in await _repo.GetAllAsync())
				Items.Add(item);
		}

		private async Task AddAsync()
		{
			var entity = new T();
			await _repo.AddAsync(entity);
			await LoadAsync();
		}

		private async Task DeleteAsync(T entity)
		{
			if (entity == null) return;
			var idProp = typeof(T).GetProperty("Id");
			if (idProp == null) return;

			var id = (int)idProp.GetValue(entity);
			await _repo.DeleteAsync(id);
			await LoadAsync();
		}
	}
}
