using System.Collections.Generic;
using System.Diagnostics;

namespace MapViewer.Domain {
	internal sealed class DataService {
		private readonly IRemoteRepository _remoteRepository;
		private readonly ILocalRepository _localRepository;

		public DataService(IRemoteRepository remoteRepository, ILocalRepository localRepository) {
			_remoteRepository = remoteRepository;
			_localRepository = localRepository;
		}

		internal IEnumerable<GasStation> GetAll() {
			var data = _localRepository.GetAll();
			if (data.Count != 0) return data;

			var newData = _remoteRepository.GetInArea(Configuration.NovosibirskArea);
			Debug.Assert(newData != null, nameof(newData) + " != null");
			_localRepository.InsertAll(newData);
			return newData;
		}
	}
}