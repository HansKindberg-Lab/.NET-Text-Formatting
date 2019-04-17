using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using HansKindberg.TextFormatting.Comparing;
using Newtonsoft.Json.Linq;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Json.Comparing
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IJsonPropertyComparerFactory))]
	public class JsonPropertyComparerFactory : IJsonPropertyComparerFactory
	{
		#region Methods

		[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
		public virtual IComparer<JProperty> Create(IJsonPropertyFormat format)
		{
			if(format == null)
				throw new ArgumentNullException(nameof(format));

			var comparer = new CompositeComparer<JProperty>();

			if(format.PinPaths.Any())
			{
				var pinJsonPropertyComparer = new PinJsonPropertyComparer
				{
					Descending = format.PinDirection == ListSortDirection.Descending
				};

				foreach(var path in format.PinPaths)
				{
					pinJsonPropertyComparer.PinPaths.Add(path);
				}

				comparer.Comparers.Add(pinJsonPropertyComparer);
			}

			if(format.AlphabeticalSort)
			{
				comparer.Comparers.Add(new AlphabeticalJsonPropertyComparer
				{
					Comparison = format.AlphabeticalComparison,
					Descending = format.AlphabeticalSortDirection == ListSortDirection.Descending
				});
			}

			return comparer;
		}

		#endregion
	}
}