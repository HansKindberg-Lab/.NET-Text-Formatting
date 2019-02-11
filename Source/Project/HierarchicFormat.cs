using System;

namespace HansKindberg.TextFormatting
{
	public class HierarchicFormat : Format, IHierarchicFormat
	{
		#region Properties

		public virtual bool Indent { get; set; }
		public virtual string IndentString { get; set; } = "\t";
		public virtual string NewLineString { get; set; } = Environment.NewLine;

		#endregion
	}
}