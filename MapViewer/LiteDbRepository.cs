using System.Collections.Generic;
using LiteDB;

namespace MapViewer {
	internal sealed class LiteDbRepository {
		private readonly string _file = Configuration.AppDirectory + "\\stations.db";

		internal IEnumerable<GasStation> GetAll() {
			using var database = new LiteDatabase(_file);
			var collection = database.GetCollection<GasStation>();
			return collection.FindAll();
		}

		internal void InsertAll(IEnumerable<GasStation> data) {
			using var database = new LiteDatabase(_file);
			var collection = database.GetCollection<GasStation>();
			collection.Insert(data);
		}
	}
}