using System;
using System.Xml;
using HansKindberg.TextFormatting.Comparing;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public class PinXmlNodeComparer : PinComparer<XmlNode>
	{
		#region Methods

		protected internal override int CompareInternal(XmlNode first, XmlNode second)
		{
			if(first == null)
				throw new ArgumentNullException(nameof(first));

			if(second == null)
				throw new ArgumentNullException(nameof(second));

			var compare = 0;
			var firstNavigator = first.CreateNavigator();
			var secondNavigator = second.CreateNavigator();

			foreach(var path in this.PinPaths)
			{
				var firstHasMatch = firstNavigator.Matches(path);
				var secondHasMatch = secondNavigator.Matches(path);

				if(firstHasMatch && !secondHasMatch)
				{
					compare = -1;
					break;
				}

				// ReSharper disable InvertIf
				if(secondHasMatch && !firstHasMatch)
				{
					compare = 1;
					break;
				}
				// ReSharper restore InvertIf
			}

			return this.InvertCompare(compare, this.Descending);
		}

		#endregion
	}
}