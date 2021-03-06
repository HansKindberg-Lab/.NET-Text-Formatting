﻿using System.Collections.Generic;
using System.Xml;

namespace HansKindberg.TextFormatting.Xml.Comparing
{
	public interface IXmlAttributeComparerFactory
	{
		#region Methods

		IComparer<XmlAttribute> Create(IXmlAttributeFormat format);

		#endregion
	}
}