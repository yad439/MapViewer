using System.Collections.Generic;

namespace MapViewer.Data {
	internal sealed class OsmrStationListDto {
		public IEnumerable<GasStationOsmrDto>? Data { get; init; }
	}
}