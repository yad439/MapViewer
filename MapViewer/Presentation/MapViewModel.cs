using System.Collections.Generic;
using System.Windows.Data;

using AutoMapper;

using MapViewer.Domain;

namespace MapViewer.Presentation {
	internal sealed class MapViewModel {
		public IReadOnlyCollection<GasStationViewModel> Stations { get; }

		public MapViewModel(DataService repository, IMapper mapper) {
			Stations = mapper.Map<IReadOnlyCollection<GasStationViewModel>>(repository.GetAll());
		}

		internal void Filter(IEnumerable<FilterCriteria<GasStationViewModel>> filters) {
			var predicate = FilteringService<GasStationViewModel>.GetPredicate(filters);
			var view = CollectionViewSource.GetDefaultView(Stations);
			view.Filter = o => predicate((GasStationViewModel)o);
		}
	}
}