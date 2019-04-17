using System.Collections.Generic;
using System.Xml;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IXmlAttributeComparerFactory))]
	public class XmlAttributeComparerFactory : XmlNodeComparerFactory<XmlAttribute>, IXmlAttributeComparerFactory
	{
		#region Methods

		public virtual IComparer<XmlAttribute> Create(IXmlAttributeFormat format)
		{
			return base.CreateInternal(format);
		}

		#endregion
	}
}