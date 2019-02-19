namespace HansKindberg.TextFormatting.Comparing
{
	public abstract class IndexedComparer<T> where T : class
	{
		#region Methods

		protected internal virtual bool TryNullIndexedCompare(IIndexed<T> first, IIndexed<T> second, out int compare)
		{
			if(this.TryNullValueCompare(first, second, out compare))
				return true;

			// ReSharper disable ConvertIfStatementToReturnStatement
			if(this.TryNullValueCompare(first?.Value, second?.Value, out compare))
				return true;
			// ReSharper restore ConvertIfStatementToReturnStatement

			return false;
		}

		protected internal virtual bool TryNullValueCompare(object first, object second, out int compare)
		{
			compare = 0;

			if(first == null)
			{
				compare = second == null ? 0 : -1;
				return true;
			}

			// ReSharper disable InvertIf
			if(second == null)
			{
				compare = 1;
				return true;
			}
			// ReSharper restore InvertIf

			return false;
		}

		#endregion
	}
}