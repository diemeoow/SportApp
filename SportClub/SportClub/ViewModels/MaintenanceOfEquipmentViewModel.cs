using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class MaintenanceOfEquipmentViewModel : BaseEntityViewModel<MaintenanceOfEquipment>
	{
		public MaintenanceOfEquipmentViewModel(IRepository<MaintenanceOfEquipment> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new MaintenanceOfEquipment
			{
				EquipmentId = 1,
				DateOfService = DateTime.UtcNow,
				Commentary = "Плановое обслуживание"
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
