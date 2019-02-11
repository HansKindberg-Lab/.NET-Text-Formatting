using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IXmlAttributeComparerFactory))]
	public class XmlAttributeComparerFactory : IXmlAttributeComparerFactory
	{
		#region Methods

		public virtual IXmlAttributeComparer Create(IXmlAttributeFormat format)
		{
			return new XmlAttributeComparer(format);
		}

		#endregion
	}
}