using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using HansKindberg.TextFormatting.Xml.Comparing;
using RegionOrebroLan;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Xml
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IXmlFormatter))]
	public class XmlFormatter : IXmlFormatter
	{
		#region Constructors

		public XmlFormatter(IXmlAttributeComparerFactory attributeComparerFactory, IXmlElementComparerFactory elementComparerFactory, IParser<XmlNode> parser)
		{
			this.AttributeComparerFactory = attributeComparerFactory ?? throw new ArgumentNullException(nameof(attributeComparerFactory));
			this.ElementComparerFactory = elementComparerFactory ?? throw new ArgumentNullException(nameof(elementComparerFactory));
			this.Parser = parser ?? throw new ArgumentNullException(nameof(parser));
		}

		#endregion

		#region Properties

		protected internal virtual IXmlAttributeComparerFactory AttributeComparerFactory { get; }
		protected internal virtual IXmlElementComparerFactory ElementComparerFactory { get; }
		protected internal virtual IParser<XmlNode> Parser { get; }

		#endregion

		#region Methods

		protected internal virtual XmlWriterSettings CreateXmlWriterSettings(Encoding encoding, IXmlFormat format, bool omitXmlDeclaration)
		{
			if(encoding == null)
				throw new ArgumentNullException(nameof(encoding));

			if(format == null)
				throw new ArgumentNullException(nameof(format));

			return new XmlWriterSettings
			{
				Encoding = encoding,
				Indent = format.Indent,
				IndentChars = format.IndentString,
				NewLineChars = format.NewLineString,
				OmitXmlDeclaration = omitXmlDeclaration
			};
		}

		public virtual string Format(IXmlFormat format, string xml)
		{
			if(format == null)
				throw new ArgumentNullException(nameof(format));

			var root = this.Parser.Parse(xml);
			var xmlDelaration = this.GetXmlDeclaration(root);
			var encoding = this.GetEncoding(xmlDelaration);

			var attributeComparer = this.AttributeComparerFactory.Create(format.AttributeFormat);
			this.SortAttributesRecursive(attributeComparer, root);

			var elementComparer = this.ElementComparerFactory.Create(format.ElementFormat);
			this.SortElementsRecursive(elementComparer, root);

			string formattedXml;

			using(var stream = new MemoryStream())
			{
				using(var xmlWriter = XmlWriter.Create(stream, this.CreateXmlWriterSettings(encoding, format, xmlDelaration == null)))
				{
					xmlWriter.WriteNode(root.CreateNavigator(), true);
				}

				var bytes = stream.ToArray().Skip(encoding.GetPreamble().Length).ToArray();
				formattedXml = encoding.GetString(bytes);
			}

			return formattedXml;
		}

		protected internal virtual Encoding GetEncoding(XmlDeclaration xmlDeclaration)
		{
			var encodingName = xmlDeclaration?.Encoding;

			return string.IsNullOrEmpty(encodingName) ? new UTF8Encoding(false) : Encoding.GetEncoding(encodingName);
		}

		protected internal virtual XmlDeclaration GetXmlDeclaration(XmlNode xmlNode)
		{
			// ReSharper disable ConstantConditionalAccessQualifier
			return xmlNode?.ChildNodes?.OfType<XmlDeclaration>().FirstOrDefault();
			// ReSharper restore ConstantConditionalAccessQualifier
		}

		[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
		protected internal virtual void SortAttributesRecursive(IComparer<XmlAttribute> comparer, XmlNode xmlNode)
		{
			if(xmlNode == null)
				throw new ArgumentNullException(nameof(xmlNode));

			if(xmlNode.Attributes != null)
			{
				foreach(var item in xmlNode.Attributes.OfType<XmlAttribute>().OrderBy(item => item, comparer))
				{
					xmlNode.Attributes.Remove(item);
					xmlNode.Attributes.Append(item);
				}
			}

			// ReSharper disable All
			if(xmlNode.ChildNodes != null)
			{
				foreach(var child in xmlNode.ChildNodes.OfType<XmlNode>())
				{
					this.SortAttributesRecursive(comparer, child);
				}
			}
			// ReSharper restore All
		}

		[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
		protected internal virtual void SortElementsRecursive(IComparer<XmlElement> comparer, XmlNode xmlNode)
		{
			if(xmlNode == null)
				throw new ArgumentNullException(nameof(xmlNode));

			//if (xmlNode.Attributes != null)
			//{
			//	foreach (var item in xmlNode.Attributes.OfType<XmlAttribute>().OrderBy(item => item, comparer))
			//	{
			//		xmlNode.Attributes.Remove(item);
			//		xmlNode.Attributes.Append(item);
			//	}
			//}

			// ReSharper disable All
			if(xmlNode.ChildNodes != null)
			{
				foreach(var child in xmlNode.ChildNodes.OfType<XmlNode>())
				{
					this.SortElementsRecursive(comparer, child);
				}

				foreach(var child in xmlNode.ChildNodes.OfType<XmlElement>().OrderBy(item => item, comparer))
				{
					xmlNode.RemoveChild(child);
					xmlNode.AppendChild(child);
				}
			}
			// ReSharper restore All
		}

		#endregion
	}
}