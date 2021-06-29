using System.ComponentModel;
using MapControl;

namespace MapViewer {
	internal sealed class GasStationViewModel : INotifyPropertyChanged {
		private string? _name;

		public int Id { get; init; }

		public string? Name {
			get => _name;
			set {
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		public Location? Location { get; init; }

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged(string name) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}