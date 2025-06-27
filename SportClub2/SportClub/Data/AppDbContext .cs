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
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<HealthIndicators> HealthIndicators { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<MaintenanceOfEquipment> MaintenanceOfEquipment { get; set; }
        public DbSet<TypeOfWorkout> TypesOfWorkout { get; set; }
        public DbSet<WorkoutGroup> WorkoutGroups { get; set; }
        public DbSet<GroupParticipant> GroupParticipants { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<CancellationExercise> CancellationExercises { get; set; }
        public DbSet<ReplacementTrainer> ReplacementTrainers { get; set; }
        public DbSet<RecordStatus> RecordStatuses { get; set; }
        public DbSet<RecordToWorkout> RecordToWorkouts { get; set; }
        public DbSet<VisitHistory> VisitHistories { get; set; }
        public DbSet<TrainerLoad> TrainerLoads { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ParticipantEvent> ParticipantEvents { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<EvaluationEvent> EvaluationEvents { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфигурации для существующих сущностей
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

            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.Specialization)
                .WithMany()
                .HasForeignKey(t => t.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

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
                .HasForeignKey(e => e.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
               .HasOne(r => r.RoomType)
               .WithMany()
               .HasForeignKey(r => r.RoomTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.SubscriptionType)
                .WithMany()
                .HasForeignKey(s => s.SubscriptionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.Type)
                .WithMany()
                .HasForeignKey(w => w.TypeOfWorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.Trainer)
                .WithMany()
                .HasForeignKey(w => w.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.Room)
                .WithMany()
                .HasForeignKey(w => w.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Конфигурации для новых сущностей
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.RoleUser)
                .WithMany()
                .HasForeignKey(u => u.RoleUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Trainer)
                .WithMany()
                .HasForeignKey(u => u.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Award>()
                .HasOne(a => a.AppUser)
                .WithMany()
                .HasForeignKey(a => a.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Award>()
                .HasOne(a => a.Event)
                .WithMany()
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingRoom>()
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingRoom>()
                .HasOne(b => b.Workout)
                .WithMany()
                .HasForeignKey(b => b.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CancellationExercise>()
                .HasOne(c => c.Workout)
                .WithMany()
                .HasForeignKey(c => c.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EvaluationEvent>()
                .HasOne(e => e.Event)
                .WithMany()
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EvaluationEvent>()
                .HasOne(e => e.AppUser)
                .WithMany()
                .HasForeignKey(e => e.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Type)
                .WithMany()
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Room)
                .WithMany()
                .HasForeignKey(e => e.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupParticipant>()
                .HasOne(g => g.WorkoutGroup)
                .WithMany()
                .HasForeignKey(g => g.WorkoutGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupParticipant>()
                .HasOne(g => g.AppUser)
                .WithMany()
                .HasForeignKey(g => g.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MaintenanceOfEquipment>()
                .HasOne(m => m.Equipment)
                .WithMany()
                .HasForeignKey(m => m.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.AppUser)
                .WithMany()
                .HasForeignKey(n => n.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParticipantEvent>()
                .HasOne(p => p.Event)
                .WithMany()
                .HasForeignKey(p => p.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParticipantEvent>()
                .HasOne(p => p.AppUser)
                .WithMany()
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecordToWorkout>()
                .HasOne(r => r.AppUser)
                .WithMany()
                .HasForeignKey(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecordToWorkout>()
                .HasOne(r => r.Workout)
                .WithMany()
                .HasForeignKey(r => r.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecordToWorkout>()
                .HasOne(r => r.RecordStatus)
                .WithMany()
                .HasForeignKey(r => r.RecordStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReplacementTrainer>()
                .HasOne(r => r.Workout)
                .WithMany()
                .HasForeignKey(r => r.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReplacementTrainer>()
                .HasOne(r => r.OldTrainer)
                .WithMany()
                .HasForeignKey(r => r.OldTrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReplacementTrainer>()
                .HasOne(r => r.NewTrainer)
                .WithMany()
                .HasForeignKey(r => r.NewTrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Workout)
                .WithMany()
                .HasForeignKey(s => s.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainerLoad>()
                .HasOne(t => t.Trainer)
                .WithMany()
                .HasForeignKey(t => t.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VisitHistory>()
                .HasOne(v => v.AppUser)
                .WithMany()
                .HasForeignKey(v => v.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VisitHistory>()
                .HasOne(v => v.Workout)
                .WithMany()
                .HasForeignKey(v => v.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutGroup>()
                .HasOne(w => w.TypeOfWorkout)
                .WithMany()
                .HasForeignKey(w => w.TypeOfWorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutGroup>()
                .HasOne(w => w.Trainer)
                .WithMany()
                .HasForeignKey(w => w.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Заполняем начальные данные
            modelBuilder.Entity<TrainerSpecialization>().HasData(
                new TrainerSpecialization { Id = 6, Name = "Фитнес" },
                new TrainerSpecialization { Id = 7, Name = "Йога" },
                new TrainerSpecialization { Id = 8, Name = "Бокс" },
                new TrainerSpecialization { Id = 9, Name = "Кроссфит" },
                new TrainerSpecialization { Id = 10, Name = "Плавание" },
                new TrainerSpecialization { Id = 11, Name = "Общая" }
            );

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

            modelBuilder.Entity<RoleUser>().HasData(
                new RoleUser { Id = 1, Name = "Администратор" },
                new RoleUser { Id = 2, Name = "Тренер" },
                new RoleUser { Id = 3, Name = "Клиент" }
            );

            modelBuilder.Entity<RecordStatus>().HasData(
                new RecordStatus { Id = 1, Name = "Запланировано" },
                new RecordStatus { Id = 2, Name = "Подтверждено" },
                new RecordStatus { Id = 3, Name = "Отменено" }
            );

            modelBuilder.Entity<EventType>().HasData(
                new EventType { Id = 1, Name = "Соревнование" },
                new EventType { Id = 2, Name = "Мастер-класс" },
                new EventType { Id = 3, Name = "Турнир" }
            );
        }

    }
}
