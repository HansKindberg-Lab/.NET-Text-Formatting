using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Json.Comparing
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IJsonPropertyComparerFactory))]
	public class JsonPropertyComparerFactory : IJsonPropertyComparerFactory
	{
		#region Methods

		public virtual IJsonPropertyComparer Create(IJsonPropertyFormat format)
		{
			return new JsonPropertyComparer(format);
		}

		#endregion
	}
}