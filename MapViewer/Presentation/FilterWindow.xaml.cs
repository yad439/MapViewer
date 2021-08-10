using MapViewer.Domain;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MapViewer.Presentation {
	internal sealed partial class FilterWindow {
		private readonly IReadOnlyCollection<GetHelper<GasStationViewModel>> _helpers;
		public ObservableCollection<FilterView> Filters { get; } = new();

		public FilterWindow(IReadOnlyCollection<GetHelper<GasStationViewModel>> helpers,
							IEnumerable<FilterEntry> saved) {
			_helpers = helpers;
			foreach (var filterEntry in saved) {
				Filters.Add(new FilterView(helpers, filterEntry));
			}

			InitializeComponent();
		}

		private void Done(object sender, System.Windows.RoutedEventArgs e) => DialogResult = true;

		private void AddFilter(object sender, System.Windows.RoutedEventArgs e) {
			Filters.Add(new FilterView(_helpers, null));
		}

		private void RemoveFilter(object sender, System.Windows.RoutedEventArgs e) {
			var index = FiltersBox.SelectedIndex;
			if (index == -1) return;

			Filters.RemoveAt(index);
		}
	}
}