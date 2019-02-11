using System;
using System.Xml;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public class XmlAttributeComparer : IXmlAttributeComparer
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
			var compareInternal = this.CompareNullable(x, y);

			if(compareInternal != null)
				return compareInternal.Value;

			compareInternal = this.CompareNullable(x?.Value, y?.Value);

			if(compareInternal != null)
				return compareInternal.Value;

			// ReSharper disable PossibleNullReferenceException

			//x.Value.CreateNavigator().Matches()
			//this.Format.Pinned

			return string.Compare(x.Value.Name, y.Value.Name, StringComparison.OrdinalIgnoreCase);

			//return x.Index.CompareTo(y.Index);

			// ReSharper restore PossibleNullReferenceException
		}

		protected internal virtual int? CompareNullable(object first, object second)
		{
			if(first == null)
			{
				if(second == null)
					return 0;

				return -1;
			}

			if(second == null)
				return 1;

			return null;
		}

		#endregion
	}
}