using System.Collections.Generic;
using System.Windows.Data;
using AutoMapper;

namespace MapViewer {
	internal sealed class MapViewModel {
		public IEnumerable<GasStationViewModel> Stations { get; }

		public MapViewModel(DataService repository, IMapper mapper) {
			Stations = mapper.Map<IEnumerable<GasStationViewModel>>(repository.GetAll());
		}

		internal void Filter(IEnumerable<FilterCriteria<GasStationViewModel>> filters) {
			var predicate = FilteringService<GasStationViewModel>.GetPredicate(filters);
			var view = CollectionViewSource.GetDefaultView(Stations);
			view.Filter = o=>predicate((GasStationViewModel)o);
		}
	}
}