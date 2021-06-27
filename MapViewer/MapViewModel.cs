using System.Collections.ObjectModel;

namespace MapViewer {
	internal sealed class MapViewModel {
		public ObservableCollection<GasStation> Stations { get; } = new();

		public MapViewModel(DataService repository) {
			foreach (var station in repository.GetAll()) {
				Stations.Add(station);
			}
		}
	}
}