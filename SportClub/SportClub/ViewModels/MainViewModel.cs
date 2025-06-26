using SportClub.Infrastructure;
using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClub.ViewModels
{
        public class TabItemModel
        {
            public string Title { get; set; }
            public object ViewModel { get; set; }
        }
	public class MainViewModel : BaseViewModel
	{
        public ObservableCollection<TabItemModel> GenericTabs { get; } = new();
        public TabItemModel SelectedTab { get; set; }
        public MainViewModel(IServiceProvider services)
        {

            void Add<T>(string title)
                where T : class, new()
            {
                var repo = services.GetRequiredService<IRepository<T>>();
                var vm = new GenericEntityViewModel<T>(repo);
                GenericTabs.Add(new TabItemModel { Title = title, ViewModel = vm });
            }
            Add<Client>("Клиенты");
            Add<Trainer>("Тренеры");
            Add<Workout>("Занятия");
            Add<Room>("Залы");
            Add<Subscription>("Абонементы");
            Add<Equipment>("Оборудование");
            Add<EquipmentType>("Типы оборудования");
            Add<EquipmentCondition>("Состояние оборудования");
            Add<SubscriptionType>("Типы абонементов");
            Add<TrainerSpecialization>("Специализации");
            Add<HealthIndicators>("Здоровье");
            Add<VisitHistory>("История посещений");
            Add<WorkoutGroup>("Группы занятий");
            Add<TypeOfWorkout>("Типы занятий");
            Add<AppUser>("Пользователи");
            Add<RoleUser>("Роли");
            Add<Award>("Награды");
            Add<BookingRoom>("Бронирование зала");
            Add<Schedule>("Расписание");
            Add<RecordToWorkout>("Записи на занятия");
            Add<RecordStatus>("Статусы записей");
            Add<GroupParticipant>("Группы участников");
            Add<Event>("События");
            Add<EventType>("Типы событий");
            Add<Notification>("Уведомления");
            Add<EvaluationEvent>("Оценка событий");
            Add<ParticipantEvent>("Участники событий");
            Add<MaintenanceOfEquipment>("Обслуживание оборудования");
            Add<ReplacementTrainer>("Замены тренеров");
            Add<TrainerLoad>("Нагрузка тренеров");
            Add<CancellationExercise>("Отмена занятий");

            SelectedTab = GenericTabs.FirstOrDefault();
            
        }
        private async Task ExportJsonAsync()
        {
            if (CurrentView is IJsonCapable vm)
                vm.ExportCommand.Execute(null);
        }
        private async Task ImportJsonAsync()
        {
            if (CurrentView is IJsonCapable vm)
                vm.ImportCommand.Execute(null);
        }
        private void OnNavigate(object param)
		{
			CurrentView = param switch
			{
				"Clients" => ClientsVM,
				"Trainers" => TrainersVM,
				"Workouts" => WorkoutsVM,
				"Subscriptions" => SubscriptionsVM,
				"Rooms" => RoomsVM,
				"Equipment" => EquipmentVM,
				_ => CurrentView
			};
			OnPropertyChanged(nameof(CurrentView));
		}
	}
}