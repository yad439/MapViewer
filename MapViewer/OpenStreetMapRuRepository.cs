using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace MapViewer {
	internal sealed class OpenStreetMapRuRepository {
		private readonly OpenStreetMapRuDataSource _dataSource;
		private readonly IMapper _mapper;

		public OpenStreetMapRuRepository(OpenStreetMapRuDataSource dataSource, IMapper mapper) {
			_dataSource = dataSource;
			_mapper = mapper;
		}

		internal GasStation[]? GetInArea(MapRectangle area) {
			var data = _dataSource.GetStationsInArea(area);
			return _mapper.Map<IEnumerable<GasStationOsmrDto>?, IEnumerable<GasStation>?>(data?.Data)?.ToArray();
		}
	}
}