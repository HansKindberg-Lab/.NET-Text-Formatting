using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HansKindberg.TextFormatting.Json
{
	public interface IJsonPropertyFormat
	{
		#region Properties

		StringComparison AlphabeticalComparison { get; }
		bool AlphabeticalSort { get; }
		ListSortDirection AlphabeticalSortDirection { get; }
		ListSortDirection PinDirection { get; }
		ISet<string> PinPaths { get; }

		#endregion
	}
}