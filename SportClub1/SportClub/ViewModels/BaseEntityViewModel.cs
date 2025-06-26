
using SportClub.Interfaces;
using SportClub.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClub.ViewModels
{
	public abstract class BaseEntityViewModel<T> : BaseViewModel where T : class
	{
		protected readonly IRepository<T> _repo;
		public ObservableCollection<T> Items { get; } = new();

		private T _selectedItem;
		public T SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				OnPropertyChanged();
			}
		}

		public ICommand LoadCommand { get; }
		public ICommand AddCommand { get; }
		public ICommand DeleteCommand { get; }
		public ICommand ImportCommand { get; }

		protected BaseEntityViewModel(IRepository<T> repo)
		{
			_repo = repo ?? throw new ArgumentNullException(nameof(repo));

			LoadCommand = new RelayCommand(async _ => await LoadAsync());
			AddCommand = new RelayCommand(async _ => await AddAsync());
			DeleteCommand = new RelayCommand(async _ => await DeleteAsync(SelectedItem));
			ImportCommand = new RelayCommand(async objs =>
			{
				if (objs is T[] array) await ImportAsync(array);
			});
		}

		public async Task LoadAsync()
		{
			Items.Clear();
			foreach (var e in await _repo.GetAllAsync())
				Items.Add(e);
		}

		public virtual Task AddAsync() => Task.CompletedTask;

		protected async Task DeleteAsync(T entity)
		{
			if (entity == null) return;
			var id = (int)typeof(T).GetProperty("Id")?.GetValue(entity);
			await _repo.DeleteAsync(id);
			await LoadAsync();
		}

		public async Task ImportAsync(IEnumerable<T> entities)
		{
			foreach (var e in entities)
				await _repo.AddAsync(e);
			await LoadAsync();
		}
	}
}
