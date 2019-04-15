using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Xml;
using HansKindberg.TextFormatting.Collections.Extensions;
using HansKindberg.TextFormatting.Xml.Comparing;
using RegionOrebroLan;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Xml
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IXmlFormatter))]
	public class XmlFormatter : IXmlFormatter
	{
		#region Constructors

		public XmlFormatter(IXmlAttributeComparerFactory attributeComparerFactory, IParser<XmlNode> parser)
		{
			this.AttributeComparerFactory = attributeComparerFactory ?? throw new ArgumentNullException(nameof(attributeComparerFactory));
			this.Parser = parser ?? throw new ArgumentNullException(nameof(parser));
		}

		#endregion

		#region Properties

		protected internal virtual IXmlAttributeComparerFactory AttributeComparerFactory { get; }
		protected internal virtual IParser<XmlNode> Parser { get; }

		#endregion

		#region Methods

		public virtual string Format(IXmlFormat format, string xml)
		{
			if(format == null)
				throw new ArgumentNullException(nameof(format));

			var root = this.Parser.Parse(xml);

			var attributeComparer = this.AttributeComparerFactory.Create(format.AttributeFormat);

			this.SortAttributesRecursive(attributeComparer, root);

			var output = new StringBuilder();

			using(var xmlWriter = XmlWriter.Create(output, new XmlWriterSettings {Indent = format.Indent, IndentChars = format.IndentString}))
			{
				xmlWriter.WriteNode(root.CreateNavigator(), true);
			}

			return output.ToString();
		}

		[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
		protected internal virtual void SortAttributesRecursive(IXmlAttributeComparer comparer, XmlNode xmlNode)
		{
			if(xmlNode == null)
				throw new ArgumentNullException(nameof(xmlNode));

			foreach(var item in xmlNode.Attributes.Indexed<XmlAttribute>().OrderBy(item => item, comparer))
			{
				// ReSharper disable PossibleNullReferenceException
				xmlNode.Attributes.Remove(item.Value);
				xmlNode.Attributes.Append(item.Value);
				// ReSharper restore PossibleNullReferenceException
			}

			foreach(var child in xmlNode.ChildNodes.OfType<XmlNode>())
			{
				this.SortAttributesRecursive(comparer, child);
			}
		}

		#endregion
	}
}