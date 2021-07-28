using System.Collections.Generic;

namespace MapViewer.Domain {
	internal interface IRemoteRepository {
		internal IList<GasStation>? GetInArea(MapRectangle area);
	}
}