using System.Collections.Generic;

namespace HansKindberg.TextFormatting.Comparing
{
	public class CompositeComparer<T> : ExtendedComparer<T>
	{
		#region Properties

		public virtual ICollection<IExtendedComparer<T>> Comparers { get; } = new List<IExtendedComparer<T>>();

		#endregion

		#region Methods

		protected internal override int CompareInternal(T first, T second)
		{
			// ReSharper disable LoopCanBeConvertedToQuery
			foreach(var comparer in this.Comparers)
			{
				var compare = comparer.Compare(first, second, true);

				if(compare != 0)
					return compare;
			}
			// ReSharper restore LoopCanBeConvertedToQuery

			return 0;
		}

		#endregion
	}
}