using System.Linq;

using AutoMapper;
using MapControl;

using MapViewer.Domain;

namespace MapViewer.Presentation {
	internal sealed partial class MainWindow {
		private readonly IMapper _mapper;
		private readonly MapViewModel _model;

		public MainWindow(MapViewModel model, IMapper mapper) {
			_mapper = mapper;
			_model = model;
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
			var helpers = new[] { new GetHelper<GasStationViewModel>("Name", typeof(string), o => o.Name) };
			var filtersDialog = new FilterWindow(helpers);

			var result = filtersDialog.ShowDialog();
			if (result.HasValue && result.Value) {
				var filters = filtersDialog.Filters.Select(f => f.GetCriteria()).ToList();
				_model.Filter(filters);
			}
		}
	}
}