using System.Collections.Generic;
using System.Xml;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public interface IXmlElementComparerFactory
	{
		#region Methods

		IComparer<XmlElement> Create(IXmlElementFormat format);

		#endregion
	}
}