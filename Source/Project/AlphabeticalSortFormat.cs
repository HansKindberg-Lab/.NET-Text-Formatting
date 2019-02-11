using System.ComponentModel;

namespace HansKindberg.TextFormatting
{
	public class AlphabeticalSortFormat : IAlphabeticalSortFormat
	{
		#region Properties

		public virtual ListSortDirection AlphabeticalSortDirection { get; set; }
		public virtual bool SortAlphabetically { get; set; }

		#endregion
	}
}