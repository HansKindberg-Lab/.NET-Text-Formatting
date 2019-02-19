using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HansKindberg.TextFormatting.Json.Comparing
{
	public interface IJsonPropertyComparer : IComparer<IIndexed<JProperty>> { }
}