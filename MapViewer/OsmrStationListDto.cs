using System.Collections.Generic;

namespace MapViewer {
	internal sealed class OsmrStationListDto {
		internal IEnumerable<GasStationOsmrDto>? Data { get; set; }
	}
}