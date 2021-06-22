using MapControl;

namespace MapViewer {
	internal sealed partial class MainWindow {
		public MainWindow(MapViewModel model) {
			InitializeComponent();
			TileImageLoader.Cache = null;
			DataContext = model;
		}
	}
}