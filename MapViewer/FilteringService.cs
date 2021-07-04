using System;
using System.Collections.Generic;
using System.Linq;

namespace MapViewer {
	internal sealed class FilteringService<T> {
		internal static Predicate<T> GetPredicate(IEnumerable<FilterCriteria<T>> filters) {
			var predicates = filters.Select(GetPredicate).ToArray();
			return obj => predicates.All(predicate => predicate(obj));
		}

		private static Predicate<T> GetPredicate(FilterCriteria<T> criteria) {
			return criteria.Value switch {
				string => MatchString(criteria),
				_      => throw new NotSupportedException("Invalid value type")
			};
		}

		private static Predicate<T> MatchString(FilterCriteria<T> criteria) {
			var value = (string)criteria.Value;
			var getter = criteria.Getter;
			return criteria.Type switch {
				FilterCriteria<T>.ComparisonType.Contains => obj =>
					(((string?)getter(obj))?.Contains(value)).GetValueOrDefault(false),
				_ => throw new Exception("Unreachable")
			};
		}
	}
}