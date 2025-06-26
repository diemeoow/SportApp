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
					services.AddTransient<ClientsViewModel>();
					services.AddTransient<TrainersViewModel>();
					services.AddTransient<WorkoutsViewModel>();
					services.AddTransient<SubscriptionsViewModel>();
					services.AddTransient<RoomsViewModel>();
					services.AddTransient<EquipmentViewModel>();
					services.AddSingleton<MainViewModel>();


                    // Views
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
	}
}
