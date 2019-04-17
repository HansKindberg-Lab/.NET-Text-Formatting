namespace HansKindberg.TextFormatting.Comparing
{
	public abstract class Comparer
	{
		#region Properties

		public virtual bool Descending { get; set; }
		public virtual bool NullIsGreatest { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// If none of the values is null will return null.
		/// </summary>
		public virtual int? CompareRegardingNull(object first, object second)
		{
			int? compare = null;

			if(first == null)
				compare = second == null ? 0 : -1;
			else if(second == null)
				compare = 1;

			if(compare != null)
				compare = this.InvertCompare(compare.Value, this.NullIsGreatest);

			return compare;
		}

		protected internal virtual int InvertCompare(int compare, bool invert)
		{
			return invert ? compare * (-1) : compare;
		}

		#endregion
	}
}