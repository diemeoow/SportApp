
using SportClub.Interfaces;
using SportClub.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClub.ViewModels
{
	public abstract class BaseEntityViewModel<T> : BaseViewModel, IJsonCapable where T : class
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
        public ICommand ExportCommand { get; }

        private readonly IJsonService _jsonService;

        protected BaseEntityViewModel(IRepository<T> repo, IJsonService jsonService)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _jsonService = jsonService ?? throw new ArgumentNullException(nameof(jsonService));

            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            DeleteCommand = new RelayCommand(async _ => await DeleteAsync(SelectedItem));
            ImportCommand = new RelayCommand(async _ => await ImportJsonAsync());
            ExportCommand = new RelayCommand(async _ => await ExportJsonAsync());
        }

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
        private async Task ImportJsonAsync()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "JSON файлы (*.json)|*.json",
				InitialDirectory = "C:\\"
            };

            if (dialog.ShowDialog() == true)
            {
                var imported = await _jsonService.ImportAsync<T>(dialog.FileName);
                await ImportAsync(imported);
            }
        }
        private async Task ExportJsonAsync()
        {
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "JSON файлы (*.json)|*.json",
                FileName = typeof(T).Name + ".json",
                InitialDirectory = "C:\\"
            };

            if (dialog.ShowDialog() == true)
            {
                await _jsonService.ExportAsync(Items, dialog.FileName);
            }
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
