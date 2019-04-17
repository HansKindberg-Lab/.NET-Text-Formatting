using System;
using System.Xml;
using HansKindberg.TextFormatting.Comparing;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public abstract class AlphabeticalXmlNodeComparer : ExtendedComparer<XmlNode>
	{
		#region Properties

		public virtual StringComparison Comparison { get; set; }

		#endregion

		#region Methods

		protected internal override int CompareInternal(XmlNode first, XmlNode second)
		{
			return this.InvertCompare(this.CompareProperty(first, second), this.Descending);
		}

		protected internal abstract int CompareProperty(XmlNode first, XmlNode second);

		#endregion
	}
}