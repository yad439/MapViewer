using System.Collections.Generic;
using System.Diagnostics;

namespace MapViewer {
	internal sealed class DataService {
		private readonly OpenStreetMapRuRepository _remoteRepository;
		private readonly LiteDbRepository _localRepository;

		public DataService(OpenStreetMapRuRepository remoteRepository, LiteDbRepository localRepository) {
			_remoteRepository = remoteRepository;
			_localRepository = localRepository;
		}

		internal IEnumerable<GasStation> GetAll() {
			var data = _localRepository.GetAll();
			if (data.Length != 0) return data;

			var newData = _remoteRepository.GetInArea(Configuration.NovosibirskArea);
			Debug.Assert(newData != null, nameof(newData) + " != null");
			_localRepository.InsertAll(newData);
			return newData;
		}
	}
}