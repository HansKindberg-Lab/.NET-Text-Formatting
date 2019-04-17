using System;
using System.Linq;
using System.Text;
using System.Xml;
using HansKindberg.TextFormatting.Xml;
using HansKindberg.TextFormatting.Xml.Comparing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RegionOrebroLan;

namespace HansKindberg.TextFormatting.UnitTests.Xml
{
	[TestClass]
	public class XmlFormatterTest
	{
		#region Methods

		protected internal virtual XmlDeclaration CreateXmlDeclaration(string encoding)
		{
			var xmlDocument = new XmlDocument();
			xmlDocument.LoadXml("<?xml version=\"1.0\" encoding=\"" + encoding + "\"?><root />");

			return xmlDocument.ChildNodes.OfType<XmlDeclaration>().FirstOrDefault();
		}

		protected internal virtual XmlFormatter CreateXmlFormatter()
		{
			return new XmlFormatter(Mock.Of<IXmlAttributeComparerFactory>(), Mock.Of<IXmlElementComparerFactory>(), Mock.Of<IParser<XmlNode>>());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetEncoding_IfTheEncodingPropertyOfTheXmlDeclarationParameterIsAWhiteSpace_ShouldThrowAnArgumentException()
		{
			var xmlDeclaration = this.CreateXmlDeclaration(" ");
			Assert.AreEqual(" ", xmlDeclaration.Encoding);
			this.CreateXmlFormatter().GetEncoding(xmlDeclaration);
		}

		[TestMethod]
		public void GetEncoding_IfTheEncodingPropertyOfTheXmlDeclarationParameterIsEmpty_ShouldReturnAnUtf8WithoutByteOrderMarkEncoding()
		{
			var xmlDeclaration = this.CreateXmlDeclaration(null);
			Assert.AreEqual(string.Empty, xmlDeclaration.Encoding);
			var encoding = this.CreateXmlFormatter().GetEncoding(xmlDeclaration);

			Assert.IsTrue(encoding is UTF8Encoding);
			Assert.AreEqual(0, encoding.GetPreamble().Length);
		}

		[TestMethod]
		public void GetEncoding_IfTheXmlDeclarationParameterIsNull_ShouldReturnAnUtf8WithoutByteOrderMarkEncoding()
		{
			var encoding = this.CreateXmlFormatter().GetEncoding(null);

			Assert.IsTrue(encoding is UTF8Encoding);
			Assert.AreEqual(0, encoding.GetPreamble().Length);
		}

		[TestMethod]
		public void GetXmlDeclaration_IfTheChildNodesPropertyOfTheXmlNodeParameterIsNull_ShouldReturnNull()
		{
			var xmlNodeMock = new Mock<XmlDocument>();

			xmlNodeMock.Setup(xmlNode => xmlNode.ChildNodes).Returns((XmlNodeList) null);

			Assert.IsNull(xmlNodeMock.Object.ChildNodes);

			Assert.IsNull(this.CreateXmlFormatter().GetXmlDeclaration(xmlNodeMock.Object));
		}

		[TestMethod]
		public void GetXmlDeclaration_IfTheXmlNodeParameterIsNull_ShouldReturnNull()
		{
			Assert.IsNull(this.CreateXmlFormatter().GetXmlDeclaration(null));
		}

		#endregion
	}
}