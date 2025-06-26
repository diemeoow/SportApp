using SportClub.Interfaces;
using SportClub.Infrastructure;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClub.ViewModels
{
	public class GenericEntityViewModel<T> : BaseViewModel where T : class
	{
		private readonly IRepository<T> _repo;
		public ObservableCollection<T> Items { get; } = new();
		private T _selectedItem;
		public T SelectedItem
		{
			get => _selectedItem;
			set { _selectedItem = value; OnPropertyChanged(); }
		}

		public string Name => typeof(T).Name; // 👈 Это нужно для TabControl!

		public ICommand LoadCommand { get; }
		public ICommand AddCommand { get; }
		public ICommand DeleteCommand { get; }

		public GenericEntityViewModel(IRepository<T> repo)
		{
			_repo = repo;

			LoadCommand = new RelayCommand(async _ => await LoadAsync());
			AddCommand = new RelayCommand(async _ => await AddAsync());
			DeleteCommand = new RelayCommand(async obj => await DeleteAsync(obj as T));
		}

		public async Task LoadAsync()
		{
			Items.Clear();
			foreach (var item in await _repo.GetAllAsync())
				Items.Add(item);
		}

		public async Task AddAsync()
		{
			var entity = System.Activator.CreateInstance<T>();
			await _repo.AddAsync(entity);
			await LoadAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			if (entity == null) return;
			var id = (int)typeof(T).GetProperty("Id").GetValue(entity);
			await _repo.DeleteAsync(id);
			await LoadAsync();
		}
	}
}
