using System.Collections.Generic;
using System.Xml;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IXmlElementComparerFactory))]
	public class XmlElementComparerFactory : XmlNodeComparerFactory<XmlElement>, IXmlElementComparerFactory
	{
		#region Methods

		public virtual IComparer<XmlElement> Create(IXmlElementFormat format)
		{
			return base.CreateInternal(format);
		}

		#endregion
	}
}