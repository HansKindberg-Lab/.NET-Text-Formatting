using System;
using HansKindberg.TextFormatting.Comparing;
using Newtonsoft.Json.Linq;

namespace HansKindberg.TextFormatting.Json.Comparing
{
	public class AlphabeticalJsonPropertyComparer : ExtendedComparer<JProperty>
	{
		#region Properties

		public virtual StringComparison Comparison { get; set; }

		#endregion

		#region Methods

		protected internal override int CompareInternal(JProperty first, JProperty second)
		{
			if(first == null)
				throw new ArgumentNullException(nameof(first));

			if(second == null)
				throw new ArgumentNullException(nameof(second));

			return this.InvertCompare(string.Compare(first.Name, second.Name, this.Comparison), this.Descending);
		}

		#endregion
	}
}