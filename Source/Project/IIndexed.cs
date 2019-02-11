namespace HansKindberg.TextFormatting
{
	public interface IIndexed<out T>
	{
		#region Properties

		int Index { get; }
		T Value { get; }

		#endregion
	}
}