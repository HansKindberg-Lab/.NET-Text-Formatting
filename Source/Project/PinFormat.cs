using System;
using System.Collections.Generic;

namespace HansKindberg.TextFormatting
{
	public class PinFormat : AlphabeticalSortFormat, IPinFormat
	{
		#region Properties

		public virtual ISet<string> Pinned { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		#endregion
	}
}