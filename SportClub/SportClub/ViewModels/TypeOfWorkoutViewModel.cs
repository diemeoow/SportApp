using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class TypeOfWorkoutViewModel : BaseEntityViewModel<TypeOfWorkout>
	{
		public TypeOfWorkoutViewModel(IRepository<TypeOfWorkout> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new TypeOfWorkout
			{
				Name = "Новый тип",
				IsIndividual = true
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
