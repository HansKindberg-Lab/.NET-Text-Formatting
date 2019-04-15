using System;
using System.Xml;
using HansKindberg.TextFormatting.Comparing;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public class XmlAttributeComparer : IndexedComparer<XmlAttribute>, IXmlAttributeComparer
	{
		#region Constructors

		public XmlAttributeComparer(IXmlAttributeFormat format)
		{
			this.Format = format ?? throw new ArgumentNullException(nameof(format));
		}

		#endregion

		#region Properties

		protected internal virtual IXmlAttributeFormat Format { get; }

		#endregion

		#region Methods

		public virtual int Compare(IIndexed<XmlAttribute> x, IIndexed<XmlAttribute> y)
		{
			if(this.TryNullIndexedCompare(x, y, out var compare))
				return compare;

			// ReSharper disable PossibleNullReferenceException

			//x.Value.CreateNavigator().Matches()
			//this.Format.Pinned

			return string.Compare(x?.Value?.Name, y?.Value?.Name, StringComparison.OrdinalIgnoreCase);

			//return x.Index.CompareTo(y.Index);

			// ReSharper restore PossibleNullReferenceException
		}

		#endregion
	}
}