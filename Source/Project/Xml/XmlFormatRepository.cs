using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Xml
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IXmlFormatRepository))]
	public class XmlFormatRepository : FormatRepository<IXmlFormat>, IXmlFormatRepository { }
}