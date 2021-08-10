using MapViewer.Domain;

namespace MapViewer.Presentation {
	internal readonly struct FilterEntry {
		internal GetHelper<GasStationViewModel> GetHelper { get; init; }
		internal object Value { get; init; }
	}
}