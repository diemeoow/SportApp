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

		public MainViewModel(
		  ClientsViewModel clients,
		  TrainersViewModel trainers,
		  WorkoutsViewModel workouts,
		  SubscriptionsViewModel subs,
		  RoomsViewModel rooms,
		  EquipmentViewModel equip,
		  IJsonService json)
		{
			ClientsVM = clients;
			TrainersVM = trainers;
			WorkoutsVM = workouts;
			SubscriptionsVM = subs;
			RoomsVM = rooms;
			EquipmentVM = equip;

			ExportJsonCommand = new RelayCommand(async _ =>
			  await json.ExportAsync(ClientsVM.Items, "clients.json"));
			ImportJsonCommand = new RelayCommand(async _ =>
			{
				var data = await json.ImportAsync<Client>("clients.json");
				await ClientsVM.ImportAsync(data);
			});
		}
	}
}
