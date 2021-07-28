namespace MapViewer.Domain {
	internal interface IRemoteRepository {
		internal GasStation[]? GetInArea(MapRectangle area);
	}
}