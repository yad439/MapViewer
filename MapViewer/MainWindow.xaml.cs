using MapControl;

namespace MapViewer {
	internal sealed partial class MainWindow {
		public MainWindow() {
			InitializeComponent();
			TileImageLoader.Cache = null;
		}
	}
}