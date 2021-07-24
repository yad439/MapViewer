using MapControl;

namespace MapViewer.Domain {
	internal sealed class GasStation {
		public int Id { get; init; }
		public string? Name { get; init; }
		public Location? Location { get; init; }
	}
}