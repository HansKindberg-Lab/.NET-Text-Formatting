using System;

namespace HansKindberg.TextFormatting.Json
{
	public interface IJsonFormat
	{
		#region Properties

		bool Indent { get; }
		int Indentation { get; }
		char IndentCharacter { get; }
		IJsonPropertyFormat PropertyFormat { get; }
		IFormatProvider Provider { get; }

		#endregion
	}
}