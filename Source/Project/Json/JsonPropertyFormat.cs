using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HansKindberg.TextFormatting.Json
{
	public class JsonPropertyFormat : IJsonPropertyFormat
	{
		#region Properties

		public virtual StringComparison AlphabeticalComparison { get; set; } = StringComparison.Ordinal;
		public virtual bool AlphabeticalSort { get; set; }
		public virtual ListSortDirection AlphabeticalSortDirection { get; set; }
		public virtual ListSortDirection PinDirection { get; set; }
		public virtual ISet<string> PinPaths { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		#endregion
	}
}