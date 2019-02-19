using HansKindberg.TextFormatting.Comparing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HansKindberg.TextFormatting.UnitTests.Comparing
{
	[TestClass]
	public class IndexedComparerTest
	{
		#region Fields

		private static readonly IndexedComparer<object> _indexedComparer = new Mock<IndexedComparer<object>> {CallBase = true}.Object;

		#endregion

		#region Properties

		protected internal virtual IndexedComparer<object> IndexedComparer => _indexedComparer;

		#endregion

		#region Methods

		[TestMethod]
		public void TryNullIndexedCompare_IfBothParametersAreNull_ShouldReturnTrueAndAnOutParameterOfZero()
		{
			Assert.IsTrue(this.IndexedComparer.TryNullIndexedCompare(null, null, out var compare));
			Assert.AreEqual(0, compare);
		}

		[TestMethod]
		public void TryNullIndexedCompare_IfBothValuesAreNull_ShouldReturnTrueAndAnOutParameterOfZero()
		{
			Assert.IsTrue(this.IndexedComparer.TryNullIndexedCompare(new Indexed<object>(), new Indexed<object>(), out var compare));
			Assert.AreEqual(0, compare);
		}

		[TestMethod]
		public void TryNullIndexedCompare_IfFirstParameterIsNotNullAndSecondParameterIsNull_ShouldReturnTrueAndAnOutParameterOfOne()
		{
			Assert.IsTrue(this.IndexedComparer.TryNullIndexedCompare(new Indexed<object>(), null, out var compare));
			Assert.AreEqual(1, compare);
		}

		[TestMethod]
		public void TryNullIndexedCompare_IfFirstParameterIsNullAndSecondParameterIsNotNull_ShouldReturnTrueAndAnOutParameterOfMinusOne()
		{
			Assert.IsTrue(this.IndexedComparer.TryNullIndexedCompare(null, new Indexed<object>(), out var compare));
			Assert.AreEqual(-1, compare);
		}

		[TestMethod]
		public void TryNullIndexedCompare_IfFirstValueIsNotNullAndSecondValueIsNull_ShouldReturnTrueAndAnOutParameterOfOne()
		{
			Assert.IsTrue(this.IndexedComparer.TryNullIndexedCompare(new Indexed<object> {Value = new object()}, new Indexed<object>(), out var compare));
			Assert.AreEqual(1, compare);
		}

		[TestMethod]
		public void TryNullIndexedCompare_IfFirstValueIsNullAndSecondValueIsNotNull_ShouldReturnTrueAndAnOutParameterOfMinusOne()
		{
			Assert.IsTrue(this.IndexedComparer.TryNullIndexedCompare(new Indexed<object>(), new Indexed<object> {Value = new object()}, out var compare));
			Assert.AreEqual(-1, compare);
		}

		#endregion
	}
}