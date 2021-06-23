using System.Collections.Generic;
using AutoMapper;

namespace MapViewer {
	internal sealed class OpenStreetMapRuRepository {
		private readonly OpenStreetMapRuDataSource _dataSource;
		private readonly IMapper _mapper;

		public OpenStreetMapRuRepository(OpenStreetMapRuDataSource dataSource, IMapper mapper) {
			_dataSource = dataSource;
			_mapper = mapper;
		}

		internal IEnumerable<GasStation>? GetStationsInArea(MapRectangle area) {
			var data = _dataSource.GetStationsInArea(area);
			return _mapper.Map<IEnumerable<GasStationOsmrDto>?, IEnumerable<GasStation>?>(data?.Data);
		}
	}
}