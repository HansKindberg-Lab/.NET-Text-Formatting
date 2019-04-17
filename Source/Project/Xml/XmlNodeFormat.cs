using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HansKindberg.TextFormatting.Xml
{
	public abstract class XmlNodeFormat : IXmlNodeFormat
	{
		#region Properties

		public virtual StringComparison AlphabeticalNameComparison { get; set; } = StringComparison.Ordinal;
		public virtual bool AlphabeticalNameSort { get; set; }
		public virtual ListSortDirection AlphabeticalNameSortDirection { get; set; }
		public virtual StringComparison AlphabeticalValueComparison { get; set; } = StringComparison.Ordinal;
		public virtual bool AlphabeticalValueSort { get; set; }
		public virtual ListSortDirection AlphabeticalValueSortDirection { get; set; }
		public virtual ListSortDirection PinDirection { get; set; }
		public virtual ISet<string> PinPaths { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		#endregion
	}
}