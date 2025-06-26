using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Infrastructure;
using SportClub.Interfaces;
using System.Windows.Input;

namespace SportClub.ViewModels
{
    public class GenericEntityViewModel<T> : BaseViewModel where T : class, new()
    {
        private readonly IRepository<T> _repository;

        public ObservableCollection<T> Items { get; } = new();

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public GenericEntityViewModel(IRepository<T> repository)
        {
            _repository = repository;

            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            DeleteCommand = new RelayCommand(async obj => await DeleteAsync(obj as T));
        }

        public async Task LoadAsync()
        {
            Items.Clear();
            foreach (var item in await _repository.GetAllAsync())
                Items.Add(item);
        }

        public async Task AddAsync()
        {
            var entity = new T();
            await _repository.AddAsync(entity);
            await LoadAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) return;

            var prop = typeof(T).GetProperty("Id");
            if (prop != null)
            {
                var id = (int)prop.GetValue(entity);
                await _repository.DeleteAsync(id);
                await LoadAsync();
            }
        }
    }
}
