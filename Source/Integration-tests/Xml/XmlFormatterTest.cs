using System;
using System.IO;
using HansKindberg.TextFormatting.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.TextFormatting.IntegrationTests.Xml
{
	[TestClass]
	public class XmlFormatterTest
	{
		#region Fields

		private static readonly string _resourcesDirectoryPath = Path.Combine(Global.ProjectDirectoryPath, @"Xml\Resources\XmlFormatterTest");

		#endregion

		#region Properties

		protected internal virtual string ResourcesDirectoryPath => _resourcesDirectoryPath;

		#endregion

		#region Methods

		//[TestMethod]
		//public void Format_Test()
		//{
		//	var formatter = Global.ServiceProvider.GetRequiredService<IXmlFormatter>();

		//	var format = new XmlFormat
		//	{
		//		//AttributeFormat = new XmlAttributeFormat
		//		//{
		//		//	SortAlphabetically = true
		//		//},
		//		Indent = true
		//	};

		//	var source = File.ReadAllText(Path.Combine(Global.ProjectDirectoryPath, @"Xml\Resources\Source", "Web.config"));

		//	var formatted = formatter.Format(format, source);

		//	var expected = File.ReadAllText(Path.Combine(Global.ProjectDirectoryPath, @"Xml\Resources\Expected", "Web.config"));

		//	Assert.AreEqual(expected, formatted);

		//	////var xmlNode = new XmlParser().Parse(File.ReadAllText(Path.Combine(Global.ProjectDirectoryPath, "Web.config")));
		//	//var xmlNode = new XmlParser().Parse("<assemblyBinding xmlns=\"urn:schemas-microsoft-com:asm.v1\" a=\"a\" />");
		//}

		[TestMethod]
		public void Format_Test_1()
		{
			var formatter = Global.ServiceProvider.GetRequiredService<IXmlFormatter>();

			var format = new XmlFormat
			{
				//AttributeFormat = new XmlAttributeFormat
				//{
				//	SortAlphabetically = true
				//},
				Indent = true,
				IndentString = "\t\t\t\t",
				NewLineString = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine
			};

			var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><root><item /></root>";

			var formatted = formatter.Format(format, xml);

			var expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + format.NewLineString + "<root>" + format.NewLineString + format.IndentString + "<item />" + format.NewLineString + "</root>";

			Assert.AreEqual(expected, formatted);
		}

		[TestMethod]
		public void Format_Test_2()
		{
			var formatter = Global.ServiceProvider.GetRequiredService<IXmlFormatter>();

			var attributeFormat = new XmlAttributeFormat
			{
				AlphabeticalNameSort = true,
				AlphabeticalValueSort = true
			};
			attributeFormat.PinPaths.Add("@pinned");

			var elementFormat = new XmlElementFormat
			{
				AlphabeticalNameSort = true,
				AlphabeticalValueSort = true
			};
			elementFormat.PinPaths.Add("pinned");

			var format = new XmlFormat
			{
				AttributeFormat = attributeFormat,
				ElementFormat = elementFormat
			};

			var xml = File.ReadAllText(Path.Combine(this.ResourcesDirectoryPath, "Format-Test-2", "Web.config"));

			var formatted = formatter.Format(format, xml);

			var expected = File.ReadAllText(Path.Combine(this.ResourcesDirectoryPath, "Format-Test-2", "Web.Expected-After-Formatting.config"));

			Assert.AreEqual(expected, formatted);
		}

		#endregion
	}
}