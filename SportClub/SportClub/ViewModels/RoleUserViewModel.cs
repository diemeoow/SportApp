using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class RoleUserViewModel : BaseEntityViewModel<RoleUser>
	{
		public RoleUserViewModel(IRepository<RoleUser> repo, IJsonService json) : base(repo, json) { }
	}
}
