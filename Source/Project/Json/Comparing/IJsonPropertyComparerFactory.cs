using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HansKindberg.TextFormatting.Json.Comparing
{
	public interface IJsonPropertyComparerFactory
	{
		#region Methods

		IComparer<JProperty> Create(IJsonPropertyFormat format);

		#endregion
	}
}