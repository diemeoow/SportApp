using Microsoft.Extensions.DependencyInjection;
using SportClub.Infrastructure;
using SportClub.Interfaces;
using SportClub.Models;
using SportClub.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SportClub.Views;

namespace SportClub.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private readonly IServiceProvider _services;
		private readonly IJsonService _jsonService;
		public ObservableCollection<string> Tables { get; } = new();
		private string _selectedTable;
		public string SelectedTable
		{
			get => _selectedTable;
			set
			{
				if (_selectedTable == value) return;
				_selectedTable = value;
				OnPropertyChanged();
				_ = LoadTableAsync();
			}
		}

		public ObservableCollection<object> Items { get; } = new();
		private object _selectedItem;
		public object SelectedItem
		{
			get => _selectedItem;
			set { _selectedItem = value; OnPropertyChanged(); }
		}
		public ICommand NavigateCommand { get; }
		public ICommand RefreshCommand { get; }
		public ICommand SaveCommand { get; }
		public ICommand AddCommand { get; }
		public ICommand DeleteCommand { get; }
		public ICommand ImportCommand { get; }
		public ICommand ExportCommand { get; }

		private Type _currentType;
		private object _currentRepo;

		private UserControl _currentView;
		public UserControl CurrentView
		{
			get => _currentView;
			set { _currentView = value; OnPropertyChanged(); }
		}
		public MainViewModel(IServiceProvider services)
		{
			_services = services;
			_jsonService = services.GetRequiredService<IJsonService>();

			RefreshCommand = new RelayCommand(async _ => await LoadTableAsync());
			SaveCommand = new RelayCommand(async _ => await SaveAsync(), _ => SelectedItem != null);
			AddCommand = new RelayCommand(_ => AddNew(), _ => _currentType != null);
			DeleteCommand = new RelayCommand(async _ => await DeleteAsync(), _ => SelectedItem != null);
			ImportCommand = new RelayCommand(async _ => await ImportAsync(), _ => _currentType != null);
			ExportCommand = new RelayCommand(async _ => await ExportAsync(), _ => Items.Any());
			NavigateCommand = new RelayCommand(param =>
			{
				if (param is string tableName)
				{
					SelectedTable = tableName; // для таблицы
					CurrentView = new GenericTableView(); // просто универсальное представление
				}
			});

			// discover tables from AppDbContext DbSet<> properties
			var ctxType = typeof(Data.AppDbContext);
			var props = ctxType.GetProperties()
				.Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Microsoft.EntityFrameworkCore.DbSet<>));
			foreach (var p in props)
				Tables.Add(p.Name);

			SelectedTable = Tables.FirstOrDefault();
		}

		private async Task LoadTableAsync()
		{
			if (string.IsNullOrEmpty(SelectedTable)) return;
			Items.Clear();
			_currentType = GetEntityType(SelectedTable);
			var repoType = typeof(IRepository<>).MakeGenericType(_currentType);
			_currentRepo = _services.GetRequiredService(repoType);
			var getAll = repoType.GetMethod("GetAllAsync");
			var task = (Task)getAll.Invoke(_currentRepo, null);
			await task.ConfigureAwait(false);
			var result = ((dynamic)task).Result as System.Collections.IEnumerable;
			foreach (var item in result)
				Items.Add(item);
		}

		private async Task SaveAsync()
		{
			var repoType = _currentRepo.GetType();
			var update = repoType.GetMethod("UpdateAsync");
			await (Task)update.Invoke(_currentRepo, new[] { SelectedItem });
			await LoadTableAsync();
		}

		private void AddNew()
		{
			if (_currentType == null) return;
			var entity = Activator.CreateInstance(_currentType);
			Items.Add(entity);
			SelectedItem = entity;
		}

		private async Task DeleteAsync()
		{
			var idProp = _currentType.GetProperty("Id");
			var id = (int)idProp.GetValue(SelectedItem);
			var repoType = _currentRepo.GetType();
			var del = repoType.GetMethod("DeleteAsync");
			await (Task)del.Invoke(_currentRepo, new object[] { id });
			await LoadTableAsync();
		}

		private async Task ImportAsync()
		{
			var dialog = new Microsoft.Win32.OpenFileDialog { Filter = "JSON files|*.json" };
			if (dialog.ShowDialog() != true) return;
			var importMethod = typeof(IJsonService)
			.GetMethod("ImportAsync")
				.MakeGenericMethod(_currentType);
			var seq = await (dynamic)importMethod.Invoke(_jsonService, new object[] { dialog.FileName });
			foreach (var e in (System.Collections.IEnumerable)seq)
				await (Task)_currentRepo.GetType()
					.GetMethod("AddAsync")
					.Invoke(_currentRepo, new[] { e });
			await LoadTableAsync();
		}

		private async Task ExportAsync()
		{
			var dialog = new Microsoft.Win32.SaveFileDialog { Filter = "JSON files|*.json" };
			if (dialog.ShowDialog() != true) return;
			var exportMethod = typeof(IJsonService)
			.GetMethod("ExportAsync")
				.MakeGenericMethod(_currentType);
			await (Task)exportMethod.Invoke(_jsonService, new object[] { Items.Cast<object>(), dialog.FileName });
		}

		private Type GetEntityType(string dbSetName)
		{
			var ctxType = typeof(Data.AppDbContext);
			var prop = ctxType.GetProperty(dbSetName);
			return prop.PropertyType.GetGenericArguments()[0];
		}
	}
}
