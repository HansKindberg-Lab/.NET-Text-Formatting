namespace HansKindberg.TextFormatting.Xml
{
	public class XmlFormat : HierarchicFormat, IXmlFormat
	{
		#region Properties

		public virtual IXmlAttributeFormat AttributeFormat { get; set; }
		public virtual IXmlElementFormat ElementFormat { get; set; }

		#endregion
	}
}