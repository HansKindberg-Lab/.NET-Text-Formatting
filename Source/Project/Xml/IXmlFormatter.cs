namespace HansKindberg.TextFormatting.Xml
{
	public interface IXmlFormatter
	{
		#region Methods

		string Format(IXmlFormat format, string xml);

		#endregion
	}
}