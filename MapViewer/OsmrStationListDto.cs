using System.Collections.Generic;

namespace MapViewer {
	internal sealed class OsmrStationListDto {
		public IEnumerable<GasStationOsmrDto>? Data { get; init; }
	}
}