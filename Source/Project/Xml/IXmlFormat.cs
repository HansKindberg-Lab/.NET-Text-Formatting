namespace HansKindberg.TextFormatting.Xml
{
	public interface IXmlFormat : IHierarchicFormat
	{
		#region Properties

		IXmlAttributeFormat AttributeFormat { get; }
		IXmlElementFormat ElementFormat { get; }

		#endregion
	}
}