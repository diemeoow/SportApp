using SportClub.Interfaces;
using SportClub.Models;
using System.Collections.ObjectModel;

namespace SportClub.ViewModels
{

	public class MainViewModel : BaseViewModel
	{
		public ObservableCollection<object> Tabs { get; }
		public object SelectedEntity { get; set; }
		public MainViewModel(
			IRepository<Notification> notificationRepo,
			IRepository<Client> clientRepo,
			IRepository<Equipment> equipmentRepo,
			IRepository<HealthIndicators> healthIndicatorsRepo,
			IRepository<GroupParticipant> groupParticipantRepo,
			IRepository<MaintenanceOfEquipment> maintenanceOfEquipmentRepo,
			IRepository<RecordToWorkout> recordToWorkoutRepo,
			IRepository<RecordStatus> recordStatusRepo,
			IRepository<ReplacementTrainer> replacementTrainerRepo,
			IRepository<RoleUser> roleUserRepo,
			IRepository<Room> roomRepo,
			IRepository<RoomType> roomTypeRepo,
			IRepository<Subscription> subscriptionRepo,
			IRepository<SubscriptionType> subscriptionTypeRepo,
			IRepository<Trainer> trainerRepo,
			IRepository<TrainerLoad> trainerLoadRepo,
			IRepository<TrainerSpecialization> trainerSpecializationRepo,
			IRepository<EquipmentType> typeOfEquipmentRepo,
			IRepository<Workout> workoutRepo,
			IRepository<WorkoutGroup> workoutGroupRepo,
			IRepository<AppUser> appUserRepo,
			IRepository<TypeOfWorkout> typeOfWorkoutRepo,
			IRepository<Award> awardRepo,
			IRepository<BookingRoom> bookingRoomRepo,
			IRepository<CancellationExercise> cancellationExerciseRepo,
			IRepository<EquipmentCondition> conditionOfEquipmentRepo,
			IRepository<VisitHistory> visitHistoryRepo,
			IRepository<EvaluationEvent> evaluationEventRepo,
			IRepository<Event> eventRepo,
			IRepository<EventType> eventTypeRepo,
			IRepository<ParticipantEvent> participantEventRepo,
			IRepository<Schedule> scheduleRepo)
		{
			Tabs = new ObservableCollection<object>
				{
					new GenericEntityViewModel<Notification>(notificationRepo),
					new GenericEntityViewModel<Client>(clientRepo),
					new GenericEntityViewModel<Equipment>(equipmentRepo),
					new GenericEntityViewModel<HealthIndicators>(healthIndicatorsRepo),
					new GenericEntityViewModel<GroupParticipant>(groupParticipantRepo),
					new GenericEntityViewModel<MaintenanceOfEquipment>(maintenanceOfEquipmentRepo),
					new GenericEntityViewModel<RecordToWorkout>(recordToWorkoutRepo),
					new GenericEntityViewModel<RecordStatus>(recordStatusRepo),
					new GenericEntityViewModel<ReplacementTrainer>(replacementTrainerRepo),
					new GenericEntityViewModel<RoleUser>(roleUserRepo),
					new GenericEntityViewModel<Room>(roomRepo),
					new GenericEntityViewModel<RoomType>(roomTypeRepo),
					new GenericEntityViewModel<Subscription>(subscriptionRepo),
					new GenericEntityViewModel<SubscriptionType>(subscriptionTypeRepo),
					new GenericEntityViewModel<Trainer>(trainerRepo),
					new GenericEntityViewModel<TrainerLoad>(trainerLoadRepo),
					new GenericEntityViewModel<TrainerSpecialization>(trainerSpecializationRepo),
					new GenericEntityViewModel<EquipmentType>(typeOfEquipmentRepo),
					new GenericEntityViewModel<Workout>(workoutRepo),
					new GenericEntityViewModel<WorkoutGroup>(workoutGroupRepo),
					new GenericEntityViewModel<AppUser>(appUserRepo),
					new GenericEntityViewModel<TypeOfWorkout>(typeOfWorkoutRepo),
					new GenericEntityViewModel<Award>(awardRepo),
					new GenericEntityViewModel<BookingRoom>(bookingRoomRepo),
					new GenericEntityViewModel<CancellationExercise>(cancellationExerciseRepo),
					new GenericEntityViewModel<EquipmentCondition>(conditionOfEquipmentRepo),
					new GenericEntityViewModel<VisitHistory>(visitHistoryRepo),
					new GenericEntityViewModel<EvaluationEvent>(evaluationEventRepo),
					new GenericEntityViewModel<Event>(eventRepo),
					new GenericEntityViewModel<EventType>(eventTypeRepo),
					new GenericEntityViewModel<ParticipantEvent>(participantEventRepo),
					new GenericEntityViewModel<Schedule>(scheduleRepo)
				};
			SelectedEntity = Tabs.FirstOrDefault();
		}
	}
}
