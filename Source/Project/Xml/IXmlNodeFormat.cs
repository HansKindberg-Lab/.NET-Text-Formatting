using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HansKindberg.TextFormatting.Xml
{
	public interface IXmlNodeFormat
	{
		#region Properties

		StringComparison AlphabeticalNameComparison { get; }
		bool AlphabeticalNameSort { get; }
		ListSortDirection AlphabeticalNameSortDirection { get; }
		StringComparison AlphabeticalValueComparison { get; }
		bool AlphabeticalValueSort { get; }
		ListSortDirection AlphabeticalValueSortDirection { get; }
		ListSortDirection PinDirection { get; }
		ISet<string> PinPaths { get; }

		#endregion
	}
}