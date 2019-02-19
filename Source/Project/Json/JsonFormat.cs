using System;
using System.Globalization;

namespace HansKindberg.TextFormatting.Json
{
	public class JsonFormat : IJsonFormat
	{
		#region Properties

		public virtual bool Indent { get; set; } = true;
		public virtual int Indentation { get; set; } = 1;
		public virtual char IndentCharacter { get; set; } = '\t';
		public virtual IJsonPropertyFormat PropertyFormat { get; set; } = new JsonPropertyFormat();
		public virtual IFormatProvider Provider { get; set; } = CultureInfo.InvariantCulture;

		#endregion
	}
}