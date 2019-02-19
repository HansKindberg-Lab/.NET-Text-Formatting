namespace HansKindberg.TextFormatting.Json
{
	public interface IJsonFormatter
	{
		#region Methods

		string Format(IJsonFormat format, string json);

		#endregion
	}
}