using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HansKindberg.TextFormatting.Collections.Extensions
{
	public static class EnumerableExtension
	{
		#region Methods

		public static IEnumerable<IIndexed<T>> Indexed<T>(this IEnumerable enumerable)
		{
			var list = new List<IIndexed<T>>();

			// ReSharper disable InvertIf
			if(enumerable != null)
			{
				var index = 0;
				foreach(var item in enumerable.Cast<T>())
				{
					list.Add(new Indexed<T>
					{
						Index = index,
						Value = item
					});

					index++;
				}
			}
			// ReSharper restore InvertIf

			return list.ToArray();
		}

		#endregion
	}
}