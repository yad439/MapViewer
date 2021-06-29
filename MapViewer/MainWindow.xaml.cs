using AutoMapper;
using MapControl;

namespace MapViewer {
	internal sealed partial class MainWindow {
		private readonly IMapper _mapper;

		public MainWindow(MapViewModel model, IMapper mapper) {
			_mapper = mapper;
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
	}
}