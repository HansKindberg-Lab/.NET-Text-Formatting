using System.Collections.Generic;

namespace HansKindberg.TextFormatting.Comparing
{
	public interface IExtendedComparer<in T> : IComparer<T>
	{
		#region Methods

		int Compare(T first, T second, bool skipCompareRegardingNull);

		#endregion
	}
}