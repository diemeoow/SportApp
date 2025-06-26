using Microsoft.Extensions.DependencyInjection;
using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SportClub.ViewModels
{
	public class TabItemModel
	{
		public string Title { get; set; }
		public object ViewModel { get; set; }
	}

	public class MainViewModel : BaseViewModel
	{
		public ObservableCollection<TabItemModel> Tabs { get; } = new();

		public MainViewModel(IServiceProvider services)
		{
			// Инициализация всех вкладок
			InitializeTabs(services);
		}

		private void InitializeTabs(IServiceProvider services)
		{
			

			// 1. Главная
			Tabs.Add(new TabItemModel
			{
				Title = "Главная",
				ViewModel = services.GetRequiredService<MainViewModel>()
			});

			// 2. Клиенты
			Tabs.Add(new TabItemModel
			{
				Title = "Клиенты",
				ViewModel = services.GetRequiredService<ClientsViewModel>()
			});

			// 3. Тренеры
			Tabs.Add(new TabItemModel
			{
				Title = "Тренеры",
				ViewModel = services.GetRequiredService<TrainersViewModel>()
			});

			// 4. Залы
			Tabs.Add(new TabItemModel
			{
				Title = "Залы",
				ViewModel = services.GetRequiredService<RoomsViewModel>()
			});

			// 5. Оборудование
			Tabs.Add(new TabItemModel
			{
				Title = "Оборудование",
				ViewModel = services.GetRequiredService<EquipmentViewModel>()
			});

			// 6. Тренировки
			Tabs.Add(new TabItemModel
			{
				Title = "Тренировки",
				ViewModel = services.GetRequiredService<WorkoutsViewModel>()
			});

			// 7. Абонементы
			Tabs.Add(new TabItemModel
			{
				Title = "Абонементы",
				ViewModel = services.GetRequiredService<SubscriptionsViewModel>()
			});

			// 8. Расписание
			Tabs.Add(new TabItemModel
			{
				Title = "Расписание",
				ViewModel = services.GetRequiredService<ScheduleViewModel>()
			});

			// 9. Замены тренеров
			Tabs.Add(new TabItemModel
			{
				Title = "Замены тренеров",
				ViewModel = services.GetRequiredService<ReplacementTrainerViewModel>()
			});

			// 10. Типы тренировок
			Tabs.Add(new TabItemModel
			{
				Title = "Типы тренировок",
				ViewModel = services.GetRequiredService<TypeOfWorkoutViewModel>()
			});

			// 11. Специализации тренеров
			Tabs.Add(new TabItemModel
			{
				Title = "Специализации",
				ViewModel = services.GetRequiredService<TrainerSpecializationViewModel>()
			});

			// 12. Нагрузка тренеров
			Tabs.Add(new TabItemModel
			{
				Title = "Нагрузка тренеров",
				ViewModel = services.GetRequiredService<TrainerLoadViewModel>()
			});

			// 13. Типы абонементов
			Tabs.Add(new TabItemModel
			{
				Title = "Типы абонементов",
				ViewModel = services.GetRequiredService<SubscriptionTypeViewModel>()
			});

			// 14. История посещений
			Tabs.Add(new TabItemModel
			{
				Title = "История посещений",
				ViewModel = services.GetRequiredService<VisitHistoryViewModel>()
			});

			// 15. Группы тренировок
			Tabs.Add(new TabItemModel
			{
				Title = "Группы тренировок",
				ViewModel = services.GetRequiredService<WorkoutGroupViewModel>()
			});

			// 16. Статусы записей
			Tabs.Add(new TabItemModel
			{
				Title = "Статусы записей",
				ViewModel = services.GetRequiredService<RecordStatusViewModel>()
			});

			// 17. Записи на тренировки
			Tabs.Add(new TabItemModel
			{
				Title = "Записи на тренировки",
				ViewModel = services.GetRequiredService<RecordToWorkoutViewModel>()
			});

			// 18. Участники мероприятий
			Tabs.Add(new TabItemModel
			{
				Title = "Участники мероприятий",
				ViewModel = services.GetRequiredService<ParticipantEventViewModel>()
			});

			// 21. Пользователи системы
			Tabs.Add(new TabItemModel
			{
				Title = "Пользователи",
				ViewModel = services.GetRequiredService<AppUserViewModel>()
			});

			// 22. Роли пользователей
			Tabs.Add(new TabItemModel
			{
				Title = "Роли",
				ViewModel = services.GetRequiredService<RoleUserViewModel>()
			});

		}
	}
}