using System.Collections.Generic;

namespace MapViewer.Domain {
	internal interface ILocalRepository {
		internal GasStation[] GetAll();
		internal void InsertAll(IEnumerable<GasStation> data);
	}
}