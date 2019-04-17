namespace HansKindberg.TextFormatting.Comparing
{
	public abstract class ExtendedComparer<T> : Comparer, IExtendedComparer<T>
	{
		#region Methods

		public virtual int Compare(T x, T y)
		{
			return this.Compare(x, y, false);
		}

		public virtual int Compare(T first, T second, bool skipCompareRegardingNull)
		{
			var compare = skipCompareRegardingNull ? null : this.CompareRegardingNull(first, second);

			// ReSharper disable ConvertIfStatementToNullCoalescingExpression
			if(compare == null)
				compare = this.CompareInternal(first, second);
			// ReSharper restore ConvertIfStatementToNullCoalescingExpression

			return compare.Value;
		}

		/// <summary>
		/// This method should preferably throw an argument-null-exception if any parameter is null.
		/// </summary>
		protected internal abstract int CompareInternal(T first, T second);

		#endregion
	}
}