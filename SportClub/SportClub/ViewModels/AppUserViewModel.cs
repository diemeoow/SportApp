using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;

namespace SportClub.ViewModels
{
	public class AppUserViewModel : BaseEntityViewModel<AppUser>
	{
		public AppUserViewModel(IRepository<AppUser> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new AppUser { Login = "Новый пользователь", Password = "123" };
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}