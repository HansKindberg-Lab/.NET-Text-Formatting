namespace HansKindberg.TextFormatting.Xml
{
	public interface IXmlFormat
	{
		#region Properties

		IXmlAttributeFormat AttributeFormat { get; }
		IXmlElementFormat ElementFormat { get; }
		bool Indent { get; }
		string IndentString { get; }
		string NewLineString { get; }

		#endregion
	}
}