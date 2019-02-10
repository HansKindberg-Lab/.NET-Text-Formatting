using System.Linq;
using HansKindberg.TextFormatting.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HansKindberg.TextFormatting.IntegrationTests
{
	[TestClass]
	public class MyTest
	{
		#region Methods

		protected internal virtual void SortJsonObject(JObject jsonObject)
		{
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
		public void Test()
		{
			var json = "{\"2-Key\":\"Value\",\"3-Key\":\"Value\",\"1-Key\":\"Value\"}";

			var jsonObject = new JsonParser().Parse(json);

			this.SortJsonObject(jsonObject);

			json = jsonObject.ToString(Formatting.None);

			Assert.AreEqual("{\"1-Key\":\"Value\",\"2-Key\":\"Value\",\"3-Key\":\"Value\"}", json);
		}

		#endregion
	}
}