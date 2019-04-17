using System.Collections.Generic;
using System.Xml;
using HansKindberg.TextFormatting.Xml.Comparing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.TextFormatting.IntegrationTests.Xml.Comparing
{
	[TestClass]
	public class PinXmlNodeComparerTest
	{
		#region Methods

		protected internal virtual XmlNode CreateXmlNode(string xml)
		{
			var xmlDocument = new XmlDocument();

			xmlDocument.LoadXml(xml);

			return xmlDocument.DocumentElement;
		}

		[TestMethod]
		public void Test()
		{
			var attributes = new List<XmlAttribute>();

			foreach(XmlAttribute attribute in this.CreateXmlNode("<root a=\"a\" b=\"b\" c=\"c\" d=\"d\" e=\"e\" />").Attributes)
			{
				attributes.Add(attribute);
			}

			Assert.AreEqual("a", attributes[0].Name);
			Assert.AreEqual("b", attributes[1].Name);
			Assert.AreEqual("c", attributes[2].Name);
			Assert.AreEqual("d", attributes[3].Name);
			Assert.AreEqual("e", attributes[4].Name);

			var pinXmlNodeComparer = new PinXmlNodeComparer();
			pinXmlNodeComparer.PinPaths.Add("@c");

			attributes.Sort(pinXmlNodeComparer);

			Assert.AreEqual("c", attributes[0].Name);
			Assert.AreEqual("a", attributes[1].Name);
			Assert.AreEqual("b", attributes[2].Name);
			Assert.AreEqual("d", attributes[3].Name);
			Assert.AreEqual("e", attributes[4].Name);

			pinXmlNodeComparer.Descending = true;

			attributes.Sort(pinXmlNodeComparer);

			Assert.AreEqual("a", attributes[0].Name);
			Assert.AreEqual("b", attributes[1].Name);
			Assert.AreEqual("d", attributes[2].Name);
			Assert.AreEqual("e", attributes[3].Name);
			Assert.AreEqual("c", attributes[4].Name);
		}

		#endregion
	}
}