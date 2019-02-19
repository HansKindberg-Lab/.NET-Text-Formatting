using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HansKindberg.TextFormatting
{
	public abstract class FormatRepository<T> : IFormatRepository<T>
	{
		#region Properties

		protected internal virtual IDictionary<string, T> Dictionary { get; } = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
		public virtual IReadOnlyDictionary<string, T> Items => (IReadOnlyDictionary<string, T>) this.Dictionary;

		#endregion

		#region Methods

		public virtual bool Delete(string name)
		{
			if(name == null)
				throw new ArgumentNullException(nameof(name));

			return this.Dictionary.Remove(name);
		}

		[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords")]
		public virtual T Get(string name)
		{
			if(name == null)
				throw new ArgumentNullException(nameof(name));

			if(!this.Dictionary.TryGetValue(name, out var format))
				format = default(T);

			return format;
		}

		public virtual void Save(T format, string name)
		{
			// ReSharper disablex JoinNullCheckWithUsage
			if(format == null)
				throw new ArgumentNullException(nameof(format));
			// ReSharper restore JoinNullCheckWithUsage

			if(name == null)
				throw new ArgumentNullException(nameof(name));

			this.Dictionary[name] = format;
		}

		#endregion
	}
}