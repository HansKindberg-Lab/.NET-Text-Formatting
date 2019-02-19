namespace HansKindberg.TextFormatting.Json.Comparing
{
	public interface IJsonPropertyComparerFactory
	{
		#region Methods

		IJsonPropertyComparer Create(IJsonPropertyFormat format);

		#endregion
	}
}