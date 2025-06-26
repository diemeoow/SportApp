using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportClub.Models;
using SportClub.Interfaces;
namespace SportClub.ViewModels
{
	public class NotificationViewModel : BaseEntityViewModel<Notification>
	{
		public NotificationViewModel(IRepository<Notification> repo, IJsonService json) : base(repo, json) { }

		public override async Task AddAsync()
		{
			var entity = new Notification
			{
				AppUserId = 1,
				Text = "Тестовое уведомление",
				SendDate = DateTime.UtcNow
			};
			await _repo.AddAsync(entity);
			await LoadAsync();
		}
	}
}
