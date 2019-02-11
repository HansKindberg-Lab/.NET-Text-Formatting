using System.ComponentModel;

namespace HansKindberg.TextFormatting
{
	public interface IAlphabeticalSortFormat
	{
		#region Properties

		ListSortDirection AlphabeticalSortDirection { get; }
		bool SortAlphabetically { get; }

		#endregion
	}
}