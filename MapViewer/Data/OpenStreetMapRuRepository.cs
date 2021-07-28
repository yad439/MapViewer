using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using MapViewer.Domain;

namespace MapViewer.Data {
	internal sealed class OpenStreetMapRuRepository : IRemoteRepository {
		private readonly OpenStreetMapRuDataSource _dataSource;
		private readonly IMapper _mapper;

		public OpenStreetMapRuRepository(OpenStreetMapRuDataSource dataSource, IMapper mapper) {
			_dataSource = dataSource;
			_mapper = mapper;
		}

		GasStation[]? IRemoteRepository.GetInArea(MapRectangle area) {
			var data = _dataSource.GetStationsInArea(area);
			return _mapper.Map<IEnumerable<GasStationOsmrDto>?, IEnumerable<GasStation>?>(data?.Data)?.ToArray();
		}
	}
}