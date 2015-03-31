using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HashCalculator
{
	public static class CoreExtensions
	{
		public static int CalculateHash(this object obj, int seed)
		{
			return CalculateHash(seed, obj);
		}

		private static int CalculateHash(int seed, object obj)
		{
			return (null == obj) ? 0 : seed * 23 + obj.GetHashCode();
		}

		public static int CalculateHash<T>(this KeyValuePair<string, T>[] pairs) where T : class
		{
			return (null == pairs) ? 0 : pairs.Aggregate(17, (i, pair) => CalculateHash(() => pair.Key, () => pair.Value));
		}

		public static int CalculateHash<T>(this IEnumerable<T> col) where T : class
		{
			return (null == col) ? 0 : col.Aggregate(17, CalculateHash);
		}

		public static int CalculateHash(this object obj, params Expression<Func<object>>[] expressions)
		{
			//Contract.Requires<ArgumentNullException>(null != expressions);

			return CalculateHash(expressions);
		}

		private static int CalculateHash(params Expression<Func<object>>[] expressions)
		{
			//Contract.Requires(null != expressions);

			var getters = Array.ConvertAll(expressions.ToArray(), expr => expr.Compile());
			return getters.Aggregate(17, (i, get) => get().CalculateHash(i));
		}

        //public static string ToJson<T>(this T obj) where T : class
        //{
        //    Contract.Ensures(null != Contract.Result<string>());

        //    if (null == obj) return string.Empty;

        //    var output = JsonConvert.SerializeObject(obj, Configuration.DefaultJsonSerializerSettings) ?? string.Empty;
        //    return output;
        //}
	}
}