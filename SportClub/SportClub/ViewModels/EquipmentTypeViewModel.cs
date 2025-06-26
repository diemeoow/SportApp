using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class EquipmentTypeViewModel : BaseEntityViewModel<EquipmentType>
	{
		public EquipmentTypeViewModel(IRepository<EquipmentType> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new EquipmentType { Name = "Новый тип" };
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
