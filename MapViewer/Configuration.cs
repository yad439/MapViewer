namespace MapViewer {
	internal static class Configuration {
		internal static readonly MapRectangle NovosibirskArea = new() {
																		  North = 55.2,
																		  South = 54.7,
																		  East = 83.25,
																		  West = 82.6
																	  };

		internal static readonly string AppDirectory = System.Reflection.Assembly.GetEntryAssembly()!.Location;
	}
}