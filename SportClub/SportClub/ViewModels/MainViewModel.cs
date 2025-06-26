using SportClub.Infrastructure;
using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClub.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public ClientsViewModel ClientsVM { get; }
		public TrainersViewModel TrainersVM { get; }
		public WorkoutsViewModel WorkoutsVM { get; }
		public SubscriptionsViewModel SubscriptionsVM { get; }
		public RoomsViewModel RoomsVM { get; }
		public EquipmentViewModel EquipmentVM { get; }

        public ICommand ExportJsonCommand { get; }
        public ICommand ImportJsonCommand { get; }
        public object CurrentView { get; private set; }
		public ICommand NavigateCommand { get; }

		public MainViewModel(
			ClientsViewModel clientsVM,
			TrainersViewModel trainersVM,
			WorkoutsViewModel workoutsVM,
			SubscriptionsViewModel subscriptionsVM,
			RoomsViewModel roomsVM,
			EquipmentViewModel equipmentVM)
		{
			ClientsVM = clientsVM;
			TrainersVM = trainersVM;
			WorkoutsVM = workoutsVM;
			SubscriptionsVM = subscriptionsVM;
			RoomsVM = roomsVM;
			EquipmentVM = equipmentVM;
            ExportJsonCommand = new RelayCommand(async _ => await ExportJsonAsync());
            ImportJsonCommand = new RelayCommand(async _ => await ImportJsonAsync());

            CurrentView = ClientsVM;
			NavigateCommand = new RelayCommand(OnNavigate);
		}
        private async Task ExportJsonAsync()
        {
            if (CurrentView is IJsonCapable vm)
                vm.ExportCommand.Execute(null);
        }
        private async Task ImportJsonAsync()
        {
            if (CurrentView is IJsonCapable vm)
                vm.ImportCommand.Execute(null);
        }
        private void OnNavigate(object param)
		{
			CurrentView = param switch
			{
				"Clients" => ClientsVM,
				"Trainers" => TrainersVM,
				"Workouts" => WorkoutsVM,
				"Subscriptions" => SubscriptionsVM,
				"Rooms" => RoomsVM,
				"Equipment" => EquipmentVM,
				_ => CurrentView
			};
			OnPropertyChanged(nameof(CurrentView));
		}
	}
}