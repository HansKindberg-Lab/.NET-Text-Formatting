using System;

namespace HansKindberg.TextFormatting.Xml
{
	public class XmlFormat : IXmlFormat
	{
		#region Properties

		public virtual IXmlAttributeFormat AttributeFormat { get; set; } = new XmlAttributeFormat();
		public virtual IXmlElementFormat ElementFormat { get; set; } = new XmlElementFormat();
		public virtual bool Indent { get; set; } = true;
		public virtual string IndentString { get; set; } = "\t";
		public virtual string NewLineString { get; set; } = Environment.NewLine;

		#endregion
	}
}