using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using HansKindberg.TextFormatting.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HansKindberg.TextFormatting.IntegrationTests.Json
{
	[TestClass]
	public class JsonFormatterTest
	{
		#region Fields

		private static readonly string _resourcesDirectoryPath = Path.Combine(Global.ProjectDirectoryPath, @"Json\Resources\JsonFormatterTest");

		#endregion

		#region Properties

		protected internal virtual string ResourcesDirectoryPath => _resourcesDirectoryPath;

		#endregion

		#region Methods

		[TestMethod]
		public void Format_Test_1()
		{
			var formatter = Global.ServiceProvider.GetRequiredService<IJsonFormatter>();

			var propertyFormat = new JsonPropertyFormat
			{
				AlphabeticalSort = true
			};
			//propertyFormat.PinPaths.Add("@pinned");

			var format = new JsonFormat
			{
				PropertyFormat = propertyFormat
			};

			var json = File.ReadAllText(Path.Combine(this.ResourcesDirectoryPath, "Format-Test-1", "Test.json"));

			var formatted = formatter.Format(format, json);

			var expected = File.ReadAllText(Path.Combine(this.ResourcesDirectoryPath, "Format-Test-1", "Test.Expected-After-Formatting.json"));

			Assert.AreEqual(expected, formatted);
		}

		[TestMethod]
		public void JsonTest()
		{
			var json = "{\"2-Key\":\"Value\",\"3-Key\":\"Value\",\"1-Key\":\"Value\"}";

			var jsonObject = new JsonParser().Parse(json);

			this.SortJsonObject(jsonObject);

			json = jsonObject.ToString(Formatting.None);

			Assert.AreEqual("{\"1-Key\":\"Value\",\"2-Key\":\"Value\",\"3-Key\":\"Value\"}", json);
		}

		[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
		protected internal virtual void SortJsonObject(JObject jsonObject)
		{
			if(jsonObject == null)
				throw new ArgumentNullException(nameof(jsonObject));

			var properties = jsonObject.Properties().ToList();

			foreach(var property in properties)
			{
				property.Remove();
			}

			foreach(var property in properties.OrderBy(item => item.Name))
			{
				jsonObject.Add(property);

				if(property.Value is JObject value)
					this.SortJsonObject(value);
			}
		}

		[TestMethod]
		public void Yeah()
		{
			//var json = "{\"2-Key\":\"Value\",\"3-Key\":\"Value\",\"1-Key\":\"Value\"}";
			var json = "{\"3-Key\":{\"B\":{\"B\":\"Value\",\"A\":\"Value\",\"C\":\"Value\"}},\"1-Key\":\"Value\",\"2-Key\":\"Value\"}";

			var jsonFormatter = Global.ServiceProvider.GetService<IJsonFormatter>();

			var formattedJson = jsonFormatter.Format(new JsonFormat(), json);
		}

		#endregion
	}
}