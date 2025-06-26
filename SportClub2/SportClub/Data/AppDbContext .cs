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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Client>()
				.HasOne(c => c.HealthIndicators)
				.WithMany()               // нет коллекции в HealthIndicators
				.HasForeignKey(c => c.HealthIndicatorsId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Client>()
				.HasOne(c => c.Subscription)
				.WithMany()               // нет коллекции в Subscription
				.HasForeignKey(c => c.SubscriptionId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Trainer>()
				.HasOne(t => t.Specialization)
				.WithMany()               // нет коллекции в TrainerSpecialization
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
			   .WithMany()               // нет коллекции в RoomType
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
