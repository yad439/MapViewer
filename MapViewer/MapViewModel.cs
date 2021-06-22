using System.Collections.ObjectModel;

namespace MapViewer {
	internal sealed class MapViewModel {
		public ObservableCollection<GasStation> Stations { get; } = new();
	}
}