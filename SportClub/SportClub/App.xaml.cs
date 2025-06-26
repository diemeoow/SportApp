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
					string connStr = "Host=localhost;Database=SportBase;Username=postgres;Password=sa";

					services.AddDbContext<AppDbContext>(options =>
						options.UseNpgsql(connStr)
							   .UseSnakeCaseNamingConvention());

					// Репозитории
					services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
					services.AddSingleton<IJsonService, JsonService>();

					// ViewModels
					services.AddSingleton<MainViewModel>();

					services.AddTransient<AppUserViewModel>();
					services.AddTransient<RoleUserViewModel>();
					services.AddTransient<ClientsViewModel>();
					services.AddTransient<TrainersViewModel>();
					services.AddTransient<WorkoutsViewModel>();
					services.AddTransient<WorkoutGroupViewModel>();
					services.AddTransient<TypeOfWorkoutViewModel>();
					services.AddTransient<SubscriptionsViewModel>();
					services.AddTransient<SubscriptionTypeViewModel>();
					services.AddTransient<HealthIndicatorsViewModel>();
					services.AddTransient<VisitHistoryViewModel>();
					services.AddTransient<TrainerLoadViewModel>();
					services.AddTransient<GroupParticipantViewModel>();
					services.AddTransient<RoomsViewModel>();
					services.AddTransient<BookingRoomViewModel>();
					services.AddTransient<ScheduleViewModel>();
					services.AddTransient<EquipmentViewModel>();
					services.AddTransient<EquipmentTypeViewModel>();
					services.AddTransient<EquipmentConditionViewModel>();
					services.AddTransient<MaintenanceOfEquipmentViewModel>();
					services.AddTransient<CancellationExerciseViewModel>();
					services.AddTransient<ReplacementTrainerViewModel>();
					services.AddTransient<EventViewModel>();
					services.AddTransient<EventTypeViewModel>();
					services.AddTransient<ParticipantEventViewModel>();
					services.AddTransient<AwardViewModel>();
					services.AddTransient<NotificationViewModel>();
					services.AddTransient<RecordToWorkoutViewModel>();
					services.AddTransient<RecordStatusViewModel>();



					// Views
					services.AddSingleton<MainWindow>(provider => new MainWindow(
				provider.GetRequiredService<MainViewModel>()
			));
				})
				.Build();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			try
			{
				AppHost.StartAsync().GetAwaiter().GetResult();
				var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
				mainWindow.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при запуске: {ex.Message}\n{ex.StackTrace}");
			}
		}
	}
}
