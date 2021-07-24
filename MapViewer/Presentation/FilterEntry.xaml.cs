using MapViewer.Domain;

using System.Collections.Generic;
using System.Windows.Controls;

namespace MapViewer.Presentation {
	internal sealed partial class FilterEntry {
		private GetHelper<GasStationViewModel> _selected = null!;
		public IEnumerable<GetHelper<GasStationViewModel>> Properties { get; }

		public GetHelper<GasStationViewModel> Selected {
			get => _selected;
			set {
				_selected = value;
				UpdateEditor(value);
			}
		}

		public FilterEntry(IList<GetHelper<GasStationViewModel>> properties) {
			Properties = properties;
			InitializeComponent();
			PropertySelectBox.SelectedIndex = 0;
		}

		public FilterCriteria<GasStationViewModel> GetCriteria() {
			var value = EditPlaceholder.Content switch {
				TextBox text => text.Text,
				_            => ""
			};
			return new FilterCriteria<GasStationViewModel>(Selected.Getter, FilterCriteria<GasStationViewModel>.ComparisonType.Contains, value);
		}

		private void UpdateEditor(GetHelper<GasStationViewModel> getHelper) {
			if (getHelper == null) return;
			if (getHelper.Type == typeof(string)) {
				EditPlaceholder.Content = new TextBox();
			}
		}
	}
}
