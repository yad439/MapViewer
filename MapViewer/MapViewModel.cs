using System.Collections.ObjectModel;

namespace MapViewer {
	internal sealed class MapViewModel {
		public ObservableCollection<GasStation> Stations { get; } = new();

		public MapViewModel(OpenStreetMapRuRepository repository) {
			foreach (var station in repository.GetStationsInArea(App.NovosibirskArea)!) {
				Stations.Add(station);
			}
		}
	}
}