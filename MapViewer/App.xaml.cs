using System.Diagnostics;
using System.Windows;

using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MapControl;

using MapViewer.Data;
using MapViewer.Domain;
using MapViewer.Presentation;

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
						   .AddSingleton<DataService>()
						   .BuildServiceProvider();

			var mainWindow = services.GetService<MainWindow>();
			Debug.Assert(mainWindow != null, nameof(mainWindow) + " != null");
			mainWindow.Show();
			mainWindow.Loaded += (_, _) => MainWindow = mainWindow;
		}

		private static MapperConfiguration ConfigureMapping() {
			var mapperConfiguration = new MapperConfiguration(cfg => {
				cfg.CreateMap<GasStationOsmrDto, GasStation>()
				   .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Location(src.Lat, src.Lon)))
				   .ForMember(dest => dest.Id, opt => opt.Ignore())
				   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameRu));
				cfg.CreateMap<GasStationViewModel, GasStationEditDto>().ReverseMap();
				cfg.CreateMap<GasStation, GasStationViewModel>();
			});
			mapperConfiguration.AssertConfigurationIsValid();
			return mapperConfiguration;
		}
	}
}