using System.Diagnostics;
using System.Windows;
using AutoMapper;
using MapControl;
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
						   .AddSingleton<OpenStreetMapRuDataSource>()
						   .AddSingleton<OpenStreetMapRuRepository>()
						   .AddSingleton<LiteDbRepository>()
						   .BuildServiceProvider();

			var mainWindow = services.GetService<MainWindow>();
			Debug.Assert(mainWindow != null, nameof(mainWindow) + " != null");
			mainWindow.Show();
			mainWindow.Loaded += (_, _) => MainWindow = mainWindow;
		}

		private static MapperConfiguration ConfigureMapping() {
			var mapperConfiguration = new MapperConfiguration(cfg => {
				cfg.CreateMap<GasStationOsmrDto, GasStation>()
				   .ForMember(
							  dest => dest.Location,
							  opt => opt.MapFrom(src => new Location(src.Lat, src.Lon))
							 );
			});
			mapperConfiguration.AssertConfigurationIsValid();
			return mapperConfiguration;
		}
	}
}