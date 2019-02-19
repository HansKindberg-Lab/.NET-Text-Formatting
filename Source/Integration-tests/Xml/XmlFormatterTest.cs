using System.IO;
using HansKindberg.TextFormatting.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.TextFormatting.IntegrationTests.Xml
{
	[TestClass]
	public class XmlFormatterTest
	{
		#region Methods

		[TestMethod]
		public void Format_Test()
		{
			var formatter = Global.ServiceProvider.GetRequiredService<IXmlFormatter>();

			var format = new XmlFormat
			{
				AttributeFormat = new XmlAttributeFormat
				{
					SortAlphabetically = true
				},
				Indent = true
			};

			var source = File.ReadAllText(Path.Combine(Global.ProjectDirectoryPath, @"Xml\Resources\Source", "Web.config"));

			var formatted = formatter.Format(format, source);

			Assert.AreEqual(string.Empty, formatted);

			////var xmlNode = new XmlParser().Parse(File.ReadAllText(Path.Combine(Global.ProjectDirectoryPath, "Web.config")));
			//var xmlNode = new XmlParser().Parse("<assemblyBinding xmlns=\"urn:schemas-microsoft-com:asm.v1\" a=\"a\" />");
		}

		#endregion
	}
}