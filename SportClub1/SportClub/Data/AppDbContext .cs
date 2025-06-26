using Microsoft.EntityFrameworkCore;
using SportClub.Models;
using System.Linq;
using System.Text.RegularExpressions;


namespace SportClub.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }

		public DbSet<Client> Clients { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Trainer> Trainers { get; set; }
		public DbSet<TrainerSpecialization> TrainerSpecializations { get; set; }
		public DbSet<Workout> Workouts { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RoomType> RoomTypes { get; set; }
		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<EquipmentType> EquipmentTypes { get; set; }
		public DbSet<EquipmentCondition> EquipmentConditions { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<HealthIndicators> HealthIndicators { get; set; }
		public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
		public DbSet<TypeOfWorkout> TypeOfWorkouts { get; set; }
		public DbSet<WorkoutGroup> WorkoutGroups { get; set; }
		public DbSet<VisitHistory> VisitHistories { get; set; }
		public DbSet<TrainerLoad> TrainerLoads { get; set; }
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<RoleUser> RoleUsers { get; set; }
		public DbSet<ReplacementTrainer> ReplacementTrainers { get; set; }
		public DbSet<RecordToWorkout> RecordToWorkouts { get; set; }
		public DbSet<RecordStatus> RecordStatuses { get; set; }
		public DbSet<ParticipantEvent> ParticipantEvents { get; set; }
		public DbSet<MaintenanceOfEquipment> MaintenanceOfEquipments { get; set; }
		public DbSet<GroupParticipant> GroupParticipants { get; set; }
		public DbSet<EventType> EventTypes { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<EvaluationEvent> EvaluationEvents { get; set; }
		public DbSet<CancellationExercise> CancellationExercises { get; set; }
		public DbSet<BookingRoom> BookingRooms { get; set; }
		public DbSet<Award> Awards { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Client>()
		.HasOne(c => c.HealthIndicators)
		.WithMany()
		.HasForeignKey(c => c.HealthIndicatorsId)
		.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Client>()
				.HasOne(c => c.Subscription)
				.WithMany()
				.HasForeignKey(c => c.SubscriptionId)
				.OnDelete(DeleteBehavior.Restrict);

			// Trainer
			modelBuilder.Entity<Trainer>()
				.HasOne(t => t.Specialization)
				.WithMany()
				.HasForeignKey("TrainerSpecializationId")
				.OnDelete(DeleteBehavior.Restrict);

			// Equipment
			modelBuilder.Entity<Equipment>()
				.HasOne(e => e.EquipmentType)
				.WithMany()
				.HasForeignKey(e => e.EquipmentTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Equipment>()
				.HasOne(e => e.EquipmentCondition)
				.WithMany()
				.HasForeignKey(e => e.EquipmentConditionId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Equipment>()
				.HasOne(e => e.Room)
				.WithMany()
				.HasForeignKey("RoomId")
				.OnDelete(DeleteBehavior.Restrict);

			// Room
			modelBuilder.Entity<Room>()
				.HasOne(r => r.RoomType)
				.WithMany()
				.HasForeignKey(r => r.RoomTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			// Subscription
			modelBuilder.Entity<Subscription>()
				.HasOne(s => s.SubscriptionType)
				.WithMany()
				.HasForeignKey(s => s.SubscriptionTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			// Workout
			modelBuilder.Entity<Workout>()
				.HasOne(w => w.Type)
				.WithMany()
				.HasForeignKey(w => w.TypeOfWorkoutId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Workout>()
				.HasOne(w => w.Trainer)
				.WithMany()
				.HasForeignKey("TrainerId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Workout>()
				.HasOne(w => w.Room)
				.WithMany()
				.HasForeignKey("RoomId")
				.OnDelete(DeleteBehavior.Restrict);

			// WorkoutGroup
			modelBuilder.Entity<WorkoutGroup>()
				.HasOne<TypeOfWorkout>()
				.WithMany()
				.HasForeignKey("TypeOfWorkoutId")
				.OnDelete(DeleteBehavior.Restrict);

			// BookingRoom
			modelBuilder.Entity<BookingRoom>()
				.HasOne<Room>()
				.WithMany()
				.HasForeignKey("RoomId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<BookingRoom>()
				.HasOne<Workout>()
				.WithMany()
				.HasForeignKey("WorkoutId")
				.OnDelete(DeleteBehavior.Restrict);

			// CancellationExercise
			modelBuilder.Entity<CancellationExercise>()
				.HasOne<Workout>()
				.WithMany()
				.HasForeignKey("WorkoutId")
				.OnDelete(DeleteBehavior.Restrict);

			// GroupParticipant
			modelBuilder.Entity<GroupParticipant>()
				.HasOne<WorkoutGroup>()
				.WithMany()
				.HasForeignKey("WorkoutGroupId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<GroupParticipant>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey("AppUserId")
				.OnDelete(DeleteBehavior.Restrict);

			// MaintenanceOfEquipment
			modelBuilder.Entity<MaintenanceOfEquipment>()
				.HasOne<Equipment>()
				.WithMany()
				.HasForeignKey("EquipmentId")
				.OnDelete(DeleteBehavior.Restrict);

			// Notification
			modelBuilder.Entity<Notification>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey("AppUserId")
				.OnDelete(DeleteBehavior.Restrict);

			// ParticipantEvent
			modelBuilder.Entity<ParticipantEvent>()
				.HasOne<Event>()
				.WithMany()
				.HasForeignKey("EventId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ParticipantEvent>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey("AppUserId")
				.OnDelete(DeleteBehavior.Restrict);

			// RecordToWorkout
			modelBuilder.Entity<RecordToWorkout>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey("AppUserId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<RecordToWorkout>()
				.HasOne<Workout>()
				.WithMany()
				.HasForeignKey("WorkoutId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<RecordToWorkout>()
				.HasOne<RecordStatus>()
				.WithMany()
				.HasForeignKey("RecordStatusId")
				.OnDelete(DeleteBehavior.Restrict);

			// ReplacementTrainer
			modelBuilder.Entity<ReplacementTrainer>()
				.HasOne<Workout>()
				.WithMany()
				.HasForeignKey("WorkoutId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ReplacementTrainer>()
				.HasOne<Trainer>()
				.WithMany()
				.HasForeignKey("OldTrainerId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ReplacementTrainer>()
				.HasOne<Trainer>()
				.WithMany()
				.HasForeignKey("NewTrainerId")
				.OnDelete(DeleteBehavior.Restrict);

			// Schedule
			modelBuilder.Entity<Schedule>()
				.HasOne<Workout>()
				.WithMany()
				.HasForeignKey("WorkoutId")
				.OnDelete(DeleteBehavior.Restrict);

			// TrainerLoad
			modelBuilder.Entity<TrainerLoad>()
				.HasOne<Trainer>()
				.WithMany()
				.HasForeignKey("TrainerId")
				.OnDelete(DeleteBehavior.Restrict);

			// VisitHistory
			modelBuilder.Entity<VisitHistory>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey("AppUserId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<VisitHistory>()
				.HasOne<Workout>()
				.WithMany()
				.HasForeignKey("WorkoutId")
				.OnDelete(DeleteBehavior.Restrict);

			// Award
			modelBuilder.Entity<Award>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey("AppUserId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Award>()
				.HasOne<Event>()
				.WithMany()
				.HasForeignKey("EventId")
				.OnDelete(DeleteBehavior.Restrict);

			// EvaluationEvent
			modelBuilder.Entity<EvaluationEvent>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey("AppUserId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<EvaluationEvent>()
				.HasOne<Event>()
				.WithMany()
				.HasForeignKey("EventId")
				.OnDelete(DeleteBehavior.Restrict);

			// AppUser
			modelBuilder.Entity<AppUser>()
				.HasOne<RoleUser>()
				.WithMany()
				.HasForeignKey("RoleUserId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<AppUser>()
				.HasOne<Trainer>()
				.WithMany()
				.HasForeignKey("TrainerId")
				.OnDelete(DeleteBehavior.Restrict);

			// Event
			modelBuilder.Entity<Event>()
				.HasOne<EventType>()
				.WithMany()
				.HasForeignKey("TypeId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Event>()
				.HasOne<Room>()
				.WithMany()
				.HasForeignKey("RoomId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<TrainerSpecialization>().HasData(
			new TrainerSpecialization { Id = 6, Name = "Фитнес" },
			new TrainerSpecialization { Id = 7, Name = "Йога" },
			new TrainerSpecialization { Id = 8, Name = "Бокс" },
			new TrainerSpecialization { Id = 9, Name = "Кроссфит" },
			new TrainerSpecialization { Id = 10, Name = "Плавание" },
			new TrainerSpecialization { Id = 11, Name = "Общая" }
			);

			// Можно сразу засеять и другие справочники
			modelBuilder.Entity<EquipmentCondition>().HasData(
				new EquipmentCondition { Id = 4, Name = "Исправно" },
				new EquipmentCondition { Id = 5, Name = "На ремонте" },
				new EquipmentCondition { Id = 6, Name = "Списано" }
			);

			modelBuilder.Entity<EquipmentType>().HasData(
				new EquipmentType { Id = 6, Name = "Беговая дорожка" },
				new EquipmentType { Id = 7, Name = "Велотренажер" },
				new EquipmentType { Id = 8, Name = "Гантели" },
				new EquipmentType { Id = 9, Name = "Турник" },
				new EquipmentType { Id = 10, Name = "Штанга" }
			);
			modelBuilder.Entity<RoomType>().HasData(
				new RoomType { Id = 6, Name = "Кардио" },
				new RoomType { Id = 7, Name = "Силовой" },
				new RoomType { Id = 8, Name = "Йога-зал" },
				new RoomType { Id = 9, Name = "Бассейн" },
				new RoomType { Id = 10, Name = "Зал единоборств" }
			);

			modelBuilder.Entity<SubscriptionType>().HasData(
				new SubscriptionType { Id = 6, Name = "Разовый", Description = "Одноразовое посещение" },
				new SubscriptionType { Id = 7, Name = "Месячный", Description = "30 дней абонемента" },
				new SubscriptionType { Id = 8, Name = "Годовой", Description = "365 дней абонемента" },
				new SubscriptionType { Id = 9, Name = "Безлимит", Description = "Безлимитные занятия" },
				new SubscriptionType { Id = 10, Name = "Утренний", Description = "Занятия с 6 до 12" }
			);

			modelBuilder.Entity<TypeOfWorkout>().HasData(
				new TypeOfWorkout { Id = 6, Name = "Кардио", IsIndividual = false, Individual = false },
				new TypeOfWorkout { Id = 7, Name = "Силовая", IsIndividual = false, Individual = false },
				new TypeOfWorkout { Id = 8, Name = "Танцевальная", IsIndividual = false, Individual = false },
				new TypeOfWorkout { Id = 9, Name = "Йога", IsIndividual = true, Individual = false },
				new TypeOfWorkout { Id = 10, Name = "Функциональная", IsIndividual = true, Individual = false }
			);

			modelBuilder.Entity<HealthIndicators>().HasData(
				new HealthIndicators { Id = 1, HealthGroup = "Группа A", Restrictions = "Ограничение 1", ValidTo = DateTime.Now.AddYears(1) },
				new HealthIndicators { Id = 2, HealthGroup = "Группа B", Restrictions = "Ограничение 2", ValidTo = DateTime.Now.AddYears(1) }
			);


		}

	}
}
