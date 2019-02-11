namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public interface IXmlAttributeComparerFactory
	{
		#region Methods

		IXmlAttributeComparer Create(IXmlAttributeFormat format);

		#endregion
	}
}