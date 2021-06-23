using System.Diagnostics;
using System.Windows;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace MapViewer {
	internal sealed partial class App {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);

			var mapping = ConfigureMapping();
			var services = new ServiceCollection()
						   .AddSingleton<MainWindow>()
						   .AddSingleton<MapViewModel>()
						   .AddSingleton<IMapper>(_ => new Mapper(mapping))
						   .BuildServiceProvider();

			var mainWindow = services.GetService<MainWindow>();
			Debug.Assert(mainWindow != null, nameof(mainWindow) + " != null");
			mainWindow.Show();
			mainWindow.Loaded += (_, _) => MainWindow = mainWindow;
		}

		private static MapperConfiguration ConfigureMapping() {
			var mapperConfiguration = new MapperConfiguration(cfg => {
				cfg.CreateMap<GasStation, GasStationOsmrDto>().ReverseMap();
			});
			mapperConfiguration.AssertConfigurationIsValid();
			return mapperConfiguration;
		}
	}
}