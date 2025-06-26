using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class EquipmentConditionViewModel : BaseEntityViewModel<EquipmentCondition>
	{
		public EquipmentConditionViewModel(IRepository<EquipmentCondition> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new EquipmentCondition { Name = "Новое состояние" };
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
