using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Json
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IJsonFormatRepository))]
	public class JsonFormatRepository : FormatRepository<IJsonFormat>, IJsonFormatRepository { }
}