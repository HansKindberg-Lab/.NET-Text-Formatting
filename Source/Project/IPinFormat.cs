using System.Collections.Generic;

namespace HansKindberg.TextFormatting
{
	public interface IPinFormat : IAlphabeticalSortFormat
	{
		#region Properties

		ISet<string> Pinned { get; }

		#endregion
	}
}