using System;
using System.Collections.Generic;

namespace HansKindberg.TextFormatting.Comparing
{
	public abstract class PinComparer<T> : ExtendedComparer<T>
	{
		#region Properties

		public virtual ISet<string> PinPaths { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		#endregion
	}
}