using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HansKindberg.TextFormatting
{
	public interface IFormatRepository<T>
	{
		#region Properties

		IReadOnlyDictionary<string, T> Items { get; }

		#endregion

		#region Methods

		bool Delete(string name);

		[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords")]
		T Get(string name);

		void Save(T format, string name);

		#endregion
	}
}