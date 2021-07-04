using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MapViewer {
	internal sealed partial class FilterWindow {
		private readonly IList<GetHelper<GasStationViewModel>> _helpers;
		public ObservableCollection<FilterEntry> Filters { get; } = new();

		public FilterWindow(IList<GetHelper<GasStationViewModel>> helpers) {
			_helpers = helpers;
			InitializeComponent();
		}

		private void Done(object sender, System.Windows.RoutedEventArgs e) => DialogResult = true;

		private void AddFilter(object sender, System.Windows.RoutedEventArgs e) { Filters.Add(new FilterEntry(_helpers)); }

		private void RemoveFilter(object sender, System.Windows.RoutedEventArgs e) {
			var index = FiltersBox.SelectedIndex;
			if (index == -1) return;

			Filters.RemoveAt(index);
		}
	}
}