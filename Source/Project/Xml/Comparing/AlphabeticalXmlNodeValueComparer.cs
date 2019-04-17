using System;
using System.Xml;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public class AlphabeticalXmlNodeValueComparer : AlphabeticalXmlNodeComparer
	{
		#region Methods

		protected internal override int CompareProperty(XmlNode first, XmlNode second)
		{
			if(first == null)
				throw new ArgumentNullException(nameof(first));

			if(second == null)
				throw new ArgumentNullException(nameof(second));

			return string.Compare(first.Value, second.Value, this.Comparison);
		}

		#endregion
	}
}