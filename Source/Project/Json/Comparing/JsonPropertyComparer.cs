using System;
using HansKindberg.TextFormatting.Comparing;
using Newtonsoft.Json.Linq;

namespace HansKindberg.TextFormatting.Json.Comparing
{
	public class JsonPropertyComparer : IndexedComparer<JProperty>, IJsonPropertyComparer
	{
		#region Constructors

		public JsonPropertyComparer(IJsonPropertyFormat format)
		{
			this.Format = format ?? throw new ArgumentNullException(nameof(format));
		}

		#endregion

		#region Properties

		protected internal virtual IJsonPropertyFormat Format { get; }

		#endregion

		#region Methods

		public virtual int Compare(IIndexed<JProperty> x, IIndexed<JProperty> y)
		{
			if(this.TryNullIndexedCompare(x, y, out var compare))
				return compare;

			// ReSharper disable PossibleNullReferenceException

			//x.Value.CreateNavigator().Matches()
			//this.Format.Pinned

			return string.Compare(x.Value.Name, y.Value.Name, StringComparison.OrdinalIgnoreCase);

			//return x.Index.CompareTo(y.Index);

			// ReSharper restore PossibleNullReferenceException
		}

		#endregion
	}
}