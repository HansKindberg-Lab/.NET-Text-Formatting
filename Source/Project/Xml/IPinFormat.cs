using System.Collections.Generic;

namespace HansKindberg.TextFormatting.Xml
{
	public interface IPinFormat : IAlphabeticalSortFormat
	{
		#region Properties

		ICollection<string> Pinned { get; }

		#endregion
	}
}