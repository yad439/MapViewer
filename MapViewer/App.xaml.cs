using System.Diagnostics;
using System.Windows;
using AutoMapper;
using MapControl;
using Microsoft.Extensions.DependencyInjection;

namespace MapViewer {
	internal sealed partial class App {
		public static readonly MapRectangle NovosibirskArea = new() {
																		North = 55.2,
																		South = 54.7,
																		East = 83.25,
																		West = 82.6
																	};

		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);

			var mapping = ConfigureMapping();
			var services = new ServiceCollection()
						   .AddSingleton<MainWindow>()
						   .AddSingleton<MapViewModel>()
						   .AddSingleton<IMapper>(_ => new Mapper(mapping))
						   .AddSingleton<OpenStreetMapRuDataSource>()
						   .AddSingleton<OpenStreetMapRuRepository>()
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