using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class TrainerSpecializationViewModel : BaseEntityViewModel<TrainerSpecialization>
	{
		public TrainerSpecializationViewModel(IRepository<TrainerSpecialization> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new TrainerSpecialization { Name = "Новая специализация" };
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
