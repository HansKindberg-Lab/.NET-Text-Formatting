using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using HansKindberg.TextFormatting.Comparing;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public abstract class XmlNodeComparerFactory<T> where T : XmlNode
	{
		#region Methods

		[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
		protected internal virtual IComparer<T> CreateInternal(IXmlNodeFormat format)
		{
			if(format == null)
				throw new ArgumentNullException(nameof(format));

			var comparer = new CompositeComparer<T>();

			if(format.PinPaths.Any())
			{
				var pinXmlNodeComparer = new PinXmlNodeComparer
				{
					Descending = format.PinDirection == ListSortDirection.Descending
				};

				foreach(var path in format.PinPaths)
				{
					pinXmlNodeComparer.PinPaths.Add(path);
				}

				comparer.Comparers.Add(pinXmlNodeComparer);
			}

			if(format.AlphabeticalNameSort)
			{
				comparer.Comparers.Add(new AlphabeticalXmlNodeNameComparer
				{
					Comparison = format.AlphabeticalNameComparison,
					Descending = format.AlphabeticalNameSortDirection == ListSortDirection.Descending
				});
			}

			if(format.AlphabeticalValueSort)
			{
				comparer.Comparers.Add(new AlphabeticalXmlNodeValueComparer
				{
					Comparison = format.AlphabeticalValueComparison,
					Descending = format.AlphabeticalValueSortDirection == ListSortDirection.Descending
				});
			}

			return comparer;
		}

		#endregion
	}
}