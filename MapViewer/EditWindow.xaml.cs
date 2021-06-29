namespace MapViewer {
	internal sealed partial class EditWindow {
		internal GasStationEditDto Data { get; }

		internal EditWindow(GasStationEditDto data) {
			Data = data;
			InitializeComponent();
			DataContext = data;
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
		}

		private void DoneEditing(object sender, System.Windows.RoutedEventArgs e) => DialogResult = true;
	}
}