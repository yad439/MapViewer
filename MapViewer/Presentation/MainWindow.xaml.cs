using System.Linq;

using AutoMapper;

using MapControl;

namespace MapViewer.Presentation {
	internal sealed partial class MainWindow {
		private readonly IMapper _mapper;
		private readonly MapViewModel _model;
		private readonly FiltersViewModel _filters;

		public MainWindow(MapViewModel model, IMapper mapper, FiltersViewModel filters) {
			_mapper = mapper;
			_model = model;
			_filters = filters;
			TileImageLoader.Cache = null;
			InitializeComponent();
			DataContext = model;
		}

		private void EditStation(object sender, System.Windows.RoutedEventArgs e) {
			if (GasStationListBox.SelectedItem is not GasStationViewModel station) return;

			var editDialog = new EditWindow(_mapper.Map<GasStationEditDto>(station)) {
								 Owner = this
							 };
			var result = editDialog.ShowDialog();
			if (result.HasValue && result.Value) {
				_ = _mapper.Map(editDialog.Data, station);
			}
		}

		private void EditFilters(object sender, System.Windows.RoutedEventArgs e) {
			var filtersDialog = new FilterWindow(_filters.AvailableFilters, _filters.Entries);

			var result = filtersDialog.ShowDialog();
			if (!result.HasValue || !result.Value) return;

			var newFilters = filtersDialog.Filters.Select(f => f.GetEntry()).ToList();
			_filters.Entries = newFilters;
			_model.Filter(_filters.Criteria);
		}
	}
}