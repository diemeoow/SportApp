using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportClub.Data;
using SportClub.Interfaces;
using SportClub.Services;
using SportClub.ViewModels;
using System.Windows;
using Npgsql.EntityFrameworkCore.PostgreSQL; // для UseNpgsql
using EFCore.NamingConventions;
using Microsoft.Extensions.Hosting;
using SportClub.Models;



namespace SportClub
{
	public partial class App : Application
	{
		public static IHost AppHost { get; private set; }

		public App()
		{
			AppHost = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					// Строка подключения
					string connStr = "Host=localhost;Database=SportBase;Username=postgres;Password=sa";

					// БД + snake_case + PostgreSQL
					services.AddDbContext<AppDbContext>(options =>
						options.UseNpgsql(connStr)
							   .UseSnakeCaseNamingConvention());

					// Общие зависимости
					services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
					services.AddSingleton<IJsonService, JsonService>();

					// Регистрация GenericEntityViewModel<T> для всех моделей
					RegisterAllEntityViewModels(services);

					// Основная VM и окно
					services.AddSingleton<MainViewModel>();
					services.AddTransient<MainWindow>();
				})
				.Build();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			AppHost.StartAsync().GetAwaiter().GetResult();

			var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
			mainWindow.Show();

			base.OnStartup(e);
		}

		private void RegisterAllEntityViewModels(IServiceCollection services)
		{
			services.AddTransient<GenericEntityViewModel<Client>>();
			services.AddTransient<GenericEntityViewModel<Trainer>>();
			services.AddTransient<GenericEntityViewModel<Workout>>();
			services.AddTransient<GenericEntityViewModel<Subscription>>();
			services.AddTransient<GenericEntityViewModel<Room>>();
			services.AddTransient<GenericEntityViewModel<Equipment>>();
			services.AddTransient<GenericEntityViewModel<HealthIndicators>>();
			services.AddTransient<GenericEntityViewModel<TrainerLoad>>();
			services.AddTransient<GenericEntityViewModel<TrainerSpecialization>>();
			services.AddTransient<GenericEntityViewModel<EquipmentType>>();
			services.AddTransient<GenericEntityViewModel<TypeOfWorkout>>();
			services.AddTransient<GenericEntityViewModel<RoleUser>>();
			services.AddTransient<GenericEntityViewModel<AppUser>>();
			services.AddTransient<GenericEntityViewModel<SubscriptionType>>();
			services.AddTransient<GenericEntityViewModel<RoomType>>();
			services.AddTransient<GenericEntityViewModel<Notification>>();
			services.AddTransient<GenericEntityViewModel<Schedule>>();
			services.AddTransient<GenericEntityViewModel<Award>>();
			services.AddTransient<GenericEntityViewModel<BookingRoom>>();
			services.AddTransient<GenericEntityViewModel<CancellationExercise>>();
			services.AddTransient<GenericEntityViewModel<EquipmentCondition>>();
			services.AddTransient<GenericEntityViewModel<EvaluationEvent>>();
			services.AddTransient<GenericEntityViewModel<Event>>();
			services.AddTransient<GenericEntityViewModel<EventType>>();
			services.AddTransient<GenericEntityViewModel<GroupParticipant>>();
			services.AddTransient<GenericEntityViewModel<MaintenanceOfEquipment>>();
			services.AddTransient<GenericEntityViewModel<ParticipantEvent>>();
			services.AddTransient<GenericEntityViewModel<RecordStatus>>();
			services.AddTransient<GenericEntityViewModel<RecordToWorkout>>();
			services.AddTransient<GenericEntityViewModel<ReplacementTrainer>>();
			services.AddTransient<GenericEntityViewModel<WorkoutGroup>>();
		}
	}
}
