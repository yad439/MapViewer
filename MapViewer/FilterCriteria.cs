using System;

namespace MapViewer {
	internal sealed class FilterCriteria<T> {
		internal Func<T,object?> Getter { get; }
		internal ComparisonType Type { get; }
		internal object Value { get; }

		public FilterCriteria(Func<T, object?> getter, ComparisonType type, object value) {
			Getter = getter;
			Type = type;
			Value = value;
		}

		internal enum ComparisonType {
			Contains
		}
	}
}