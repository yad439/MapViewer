using System.Collections.Generic;
using AutoMapper;

namespace MapViewer {
	internal sealed class MapViewModel {
		public IEnumerable<GasStationViewModel> Stations { get; }

		public MapViewModel(DataService repository, IMapper mapper) {
			Stations = mapper.Map<IEnumerable<GasStationViewModel>>(repository.GetAll());
		}
	}
}