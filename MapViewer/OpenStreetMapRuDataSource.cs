using System.Globalization;
using RestSharp;

namespace MapViewer {
	internal sealed class OpenStreetMapRuDataSource {
		private readonly RestClient _client = new("http://openstreetmap.ru/api/poi");

		// ReSharper disable once ReturnTypeCanBeNotNullable
		internal OsmrStationListDto? GetStationsInArea(MapRectangle area) {
			var request = new RestRequest("", DataFormat.Json)
						  .AddQueryParameter("action", "getpoibbox")
						  .AddQueryParameter("nclass", "fuel")
						  .AddQueryParameter("t", area.North.ToString(CultureInfo.InvariantCulture))
						  .AddQueryParameter("b", area.South.ToString(CultureInfo.InvariantCulture))
						  .AddQueryParameter("l", area.West.ToString(CultureInfo.InvariantCulture))
						  .AddQueryParameter("r", area.East.ToString(CultureInfo.InvariantCulture));
			var response = _client.Get<OsmrStationListDto>(request);
			return response.Data;
		}
	}
}