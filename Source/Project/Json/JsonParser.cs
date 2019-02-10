using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegionOrebroLan;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Json
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IParser<JObject>))]
	public class JsonParser : BasicParser<JObject>
	{
		#region Methods

		public override JObject Parse(string value)
		{
			return JsonConvert.DeserializeObject<JObject>(value);
		}

		#endregion
	}
}