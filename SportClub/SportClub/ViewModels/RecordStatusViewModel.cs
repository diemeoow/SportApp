using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SportClub.ViewModels
{
	public class RecordStatusViewModel : BaseEntityViewModel<RecordStatus>
	{
		public RecordStatusViewModel(IRepository<RecordStatus> repo, IJsonService json)
			: base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new RecordStatus { Name = "Новый статус" };
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
