using Microsoft.EntityFrameworkCore;
using SportClub.Models;
using System.Linq;

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

	}
}
