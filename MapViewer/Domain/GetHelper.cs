using System;

namespace MapViewer.Domain {
	internal sealed class GetHelper<T> {
		public string Name { get; }
		internal Type Type { get; }
		internal Func<T, object?> Getter { get; }

		internal GetHelper(string name, Type type, Func<T, object?> getter) {
			Name = name;
			Type = type;
			Getter = getter;
		}
	}
}