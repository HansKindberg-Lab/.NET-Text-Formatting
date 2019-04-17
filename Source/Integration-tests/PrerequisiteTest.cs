using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.TextFormatting.IntegrationTests
{
	[TestClass]
	public class PrerequisiteTest
	{
		#region Methods

		[TestMethod]
		public void Compare_ReturningZero_ShouldNotAffectTheOrder()
		{
			var list = new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("A", 0),
				new KeyValuePair<string, int>("a", 1),
				new KeyValuePair<string, int>("A", 2),
				new KeyValuePair<string, int>("a", 3),
				new KeyValuePair<string, int>("A", 4)
			};

			Assert.AreEqual("A", list[0].Key);
			Assert.AreEqual(0, list[0].Value);
			Assert.AreEqual("a", list[1].Key);
			Assert.AreEqual(1, list[1].Value);
			Assert.AreEqual("A", list[2].Key);
			Assert.AreEqual(2, list[2].Value);
			Assert.AreEqual("a", list[3].Key);
			Assert.AreEqual(3, list[3].Value);
			Assert.AreEqual("A", list[4].Key);
			Assert.AreEqual(4, list[4].Value);

			list.Sort((first, secoond) => 0);

			Assert.AreEqual("A", list[0].Key);
			Assert.AreEqual(0, list[0].Value);
			Assert.AreEqual("a", list[1].Key);
			Assert.AreEqual(1, list[1].Value);
			Assert.AreEqual("A", list[2].Key);
			Assert.AreEqual(2, list[2].Value);
			Assert.AreEqual("a", list[3].Key);
			Assert.AreEqual(3, list[3].Value);
			Assert.AreEqual("A", list[4].Key);
			Assert.AreEqual(4, list[4].Value);
		}

		[TestMethod]
		public void EmptyUtf8Encoding_OpenRead_Test()
		{
			using(var stream = File.OpenRead(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-Encoding.txt")))
			{
				Assert.AreEqual(0, stream.Length);
				Assert.AreEqual(0, stream.Position);
			}
		}

		[TestMethod]
		public void EmptyUtf8Encoding_ReadAllBytes_Test()
		{
			var bytes = File.ReadAllBytes(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-Encoding.txt"));

			Assert.AreEqual(0, bytes.Length);
		}

		[TestMethod]
		public void EmptyUtf8Encoding_ReadAllText_Test()
		{
			var text = File.ReadAllText(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-Encoding.txt"));

			Assert.AreEqual(string.Empty, text);
		}

		[TestMethod]
		public void EmptyUtf8Encoding_StreamReader_Test()
		{
			// https://www.codeproject.com/Tips/1231324/How-to-Get-a-Files-Encoding-with-Csharp

			using(var streamReader = new StreamReader(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-Encoding.txt"), Encoding.Default, true))
			{
				if(streamReader.Peek() >= 0) // you need this!
					streamReader.Read();

				var encoding = streamReader.CurrentEncoding;

				Assert.AreEqual("utf-8", encoding.BodyName);
				Assert.AreEqual(0, encoding.Preamble.Length);
			}
		}

		[TestMethod]
		public void EmptyUtf8WithBomEncoding_OpenRead_Test()
		{
			using(var stream = File.OpenRead(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-With-BOM-Encoding.txt")))
			{
				Assert.AreEqual(3, stream.Length);
				Assert.AreEqual(0, stream.Position);
			}
		}

		[TestMethod]
		public void EmptyUtf8WithBomEncoding_ReadAllBytes_Test()
		{
			var bytes = File.ReadAllBytes(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-With-BOM-Encoding.txt"));

			Assert.AreEqual(3, bytes.Length);
		}

		[TestMethod]
		public void EmptyUtf8WithBomEncoding_ReadAllText_Test()
		{
			var text = File.ReadAllText(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-With-BOM-Encoding.txt"));

			Assert.AreEqual(string.Empty, text);
		}

		[TestMethod]
		public void EmptyUtf8WithBomEncoding_StreamReader_Test()
		{
			// https://www.codeproject.com/Tips/1231324/How-to-Get-a-Files-Encoding-with-Csharp

			using(var streamReader = new StreamReader(Path.Combine(Global.ProjectDirectoryPath, "Resources", "Empty-UTF-8-With-BOM-Encoding.txt"), Encoding.Default, true))
			{
				if(streamReader.Peek() >= 0) // you need this!
					streamReader.Read();

				var encoding = streamReader.CurrentEncoding;

				Assert.AreEqual("utf-8", encoding.BodyName);
				Assert.AreEqual(3, encoding.Preamble.Length);
			}
		}

		#endregion
	}
}