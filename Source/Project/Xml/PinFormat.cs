using System;
using System.Collections.Generic;

namespace HansKindberg.TextFormatting.Xml
{
	public class PinFormat : AlphabeticalSortFormat, IPinFormat
	{
		#region Properties

		public virtual ICollection<string> Pinned { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		#endregion
	}
}