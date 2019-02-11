using System.Xml;
using RegionOrebroLan;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Xml
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IParser<XmlNode>))]
	public class XmlParser : BasicParser<XmlNode>
	{
		#region Methods

		public override XmlNode Parse(string value)
		{
			var xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(value);

			return xmlDocument;
		}

		#endregion
	}
}