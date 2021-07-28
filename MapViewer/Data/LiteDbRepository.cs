using System.Collections.Generic;
using System.Linq;

using LiteDB;

using MapViewer.Domain;

namespace MapViewer.Data {
	internal sealed class LiteDbRepository : ILocalRepository {
		private readonly string _file = Configuration.AppDirectory + "\\stations.db";

		GasStation[] ILocalRepository.GetAll() {
			using var database = new LiteDatabase(_file);
			var collection = database.GetCollection<GasStation>();
			return collection.FindAll().ToArray();
		}

		void ILocalRepository.InsertAll(IEnumerable<GasStation> data) {
			using var database = new LiteDatabase(_file);
			var collection = database.GetCollection<GasStation>();
			collection.Insert(data);
		}
	}
}