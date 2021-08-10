using MapViewer.Domain;

using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

namespace MapViewer.Presentation {
	internal sealed partial class FilterView {
		private GetHelper<GasStationViewModel> _selected = null!;
		public IReadOnlyCollection<GetHelper<GasStationViewModel>> Properties { get; }

		public GetHelper<GasStationViewModel> Selected {
			get => _selected;
			set {
				_selected = value;
				UpdateEditor(value);
			}
		}

		public FilterView(IReadOnlyCollection<GetHelper<GasStationViewModel>> properties, FilterEntry? selected) {
			Properties = properties;
			InitializeComponent();
			if (selected is { } selectedEntry) {
				PropertySelectBox.SelectedValue = selectedEntry.GetHelper;
				SetValue(selectedEntry.Value);
			} else PropertySelectBox.SelectedIndex = 0;
		}

		public FilterEntry GetEntry() {
			var value = EditPlaceholder.Content switch {
				TextBox text => text.Text,
				_            => ""
			};
			return new FilterEntry { GetHelper = Selected, Value = value };
		}

		private void UpdateEditor(GetHelper<GasStationViewModel>? getHelper) {
			if (getHelper is null) return;

			if (getHelper.Type == typeof(string)) {
				EditPlaceholder.Content = new TextBox();
			}
		}

		private void SetValue(object? value) {
			switch (value) {
				case string s:
					Debug.Assert(EditPlaceholder.Content is TextBox);
					((TextBox)EditPlaceholder.Content).Text = s;
					break;
			}
		}
	}
}