using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using HansKindberg.TextFormatting.Collections.Extensions;
using HansKindberg.TextFormatting.Json.Comparing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegionOrebroLan;
using RegionOrebroLan.ServiceLocation;

namespace HansKindberg.TextFormatting.Json
{
	[ServiceConfiguration(InstanceMode = InstanceMode.Singleton, ServiceType = typeof(IJsonFormatter))]
	public class JsonFormatter : IJsonFormatter
	{
		#region Constructors

		public JsonFormatter(IParser<JObject> parser, IJsonPropertyComparerFactory propertyComparerFactory)
		{
			this.Parser = parser ?? throw new ArgumentNullException(nameof(parser));
			this.PropertyComparerFactory = propertyComparerFactory ?? throw new ArgumentNullException(nameof(propertyComparerFactory));
		}

		#endregion

		#region Properties

		protected internal virtual IParser<JObject> Parser { get; }
		protected internal virtual IJsonPropertyComparerFactory PropertyComparerFactory { get; }

		#endregion

		#region Methods

		public virtual string Format(IJsonFormat format, string json)
		{
			if(format == null)
				throw new ArgumentNullException(nameof(format));

			var root = this.Parser.Parse(json);

			var propertyComparer = this.PropertyComparerFactory.Create(format.PropertyFormat);

			this.SortPropertiesRecursive(propertyComparer, root);

			var jsonSerializer = JsonSerializer.CreateDefault();
			using(var stringWriter = new StringWriter(format.Provider))
			{
				using(var jsonTextWriter = new JsonTextWriter(stringWriter))
				{
					jsonTextWriter.Formatting = format.Indent ? Formatting.Indented : Formatting.None;
					jsonTextWriter.Indentation = format.Indentation;
					jsonTextWriter.IndentChar = format.IndentCharacter;

					jsonSerializer.Serialize(jsonTextWriter, root, root.GetType());
				}

				return stringWriter.ToString();
			}
		}

		[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
		protected internal virtual void SortPropertiesRecursive(IJsonPropertyComparer comparer, JObject value)
		{
			if(value == null)
				throw new ArgumentNullException(nameof(value));

			var properties = value.Properties().ToList();

			foreach(var property in properties)
			{
				property.Remove();
			}

			foreach(var item in properties.Indexed<JProperty>().OrderBy(item => item, comparer))
			{
				value.Add(item.Value);

				if(item.Value.Value is JObject child)
					this.SortPropertiesRecursive(comparer, child);
			}
		}

		#endregion
	}
}