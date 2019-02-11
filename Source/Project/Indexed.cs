namespace HansKindberg.TextFormatting
{
	public class Indexed<T> : IIndexed<T>
	{
		#region Properties

		public virtual int Index { get; set; }
		public virtual T Value { get; set; }

		#endregion
	}
}