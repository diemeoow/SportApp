using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportClub.Data;
using SportClub.Interfaces;
using SportClub.Services;
using SportClub.ViewModels;
using System.Windows;
using Npgsql.EntityFrameworkCore.PostgreSQL; // для UseNpgsql
using EFCore.NamingConventions;

namespace SportClub
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			var services = new ServiceCollection();

			services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql("Host=localhost;Database=SportBase;Username=postgres;Password=sa")
		   .UseSnakeCaseNamingConvention()); 

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddSingleton<IJsonService, JsonService>();

			services.AddTransient<ClientsViewModel>();
			services.AddTransient<TrainersViewModel>();
			services.AddTransient<WorkoutsViewModel>();
			services.AddTransient<SubscriptionsViewModel>();
			services.AddTransient<RoomsViewModel>();
			services.AddTransient<EquipmentViewModel>();
			services.AddTransient<MainViewModel>();
			services.AddTransient<MainWindow>();

			var provider = services.BuildServiceProvider();
			var main = provider.GetRequiredService<MainWindow>();
			main.Show();

			base.OnStartup(e);
		}
	}
}
