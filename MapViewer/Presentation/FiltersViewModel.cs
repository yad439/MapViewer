using System.Collections.Generic;
using System.Linq;

using MapViewer.Domain;

namespace MapViewer.Presentation {
	internal sealed class FiltersViewModel {
		internal IReadOnlyCollection<GetHelper<GasStationViewModel>> AvailableFilters { get; }

		internal IReadOnlyCollection<FilterEntry> Entries { get; set; } = new List<FilterEntry>();

		internal IEnumerable<FilterCriteria<GasStationViewModel>> Criteria =>
			Entries.Select(e => new FilterCriteria<GasStationViewModel>(e.GetHelper.Getter,
																		FilterCriteria<GasStationViewModel>
																			.ComparisonType.Contains,
																		e.Value));

		public FiltersViewModel(IReadOnlyCollection<GetHelper<GasStationViewModel>> availableFilters) {
			AvailableFilters = availableFilters;
		}
	}
}