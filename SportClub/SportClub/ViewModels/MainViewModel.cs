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

			CurrentView = ClientsVM;
			NavigateCommand = new RelayCommand(OnNavigate);
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