namespace HansKindberg.TextFormatting
{
	public interface IHierarchicFormat : IFormat
	{
		#region Properties

		bool Indent { get; }
		string IndentString { get; }
		string NewLineString { get; }

		#endregion
	}
}