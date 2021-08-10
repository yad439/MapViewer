using System.Collections.Generic;
using System.IO;
using System.Reflection;

using MapViewer.Domain;
using MapViewer.Presentation;

namespace MapViewer {
	internal static class Configuration {
		internal static readonly MapRectangle NovosibirskArea = new() {
																		  North = 55.2,
																		  South = 54.7,
																		  East = 83.25,
																		  West = 82.6
																	  };

		internal static readonly IReadOnlyCollection<GetHelper<GasStationViewModel>> AvailableFilters =
			new List<GetHelper<GasStationViewModel>> { new("Name", typeof(string), it => it.Name) };

		internal static readonly string AppDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;
	}
}