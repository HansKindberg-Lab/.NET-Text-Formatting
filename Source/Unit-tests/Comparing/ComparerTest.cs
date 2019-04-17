using HansKindberg.TextFormatting.Comparing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HansKindberg.TextFormatting.UnitTests.Comparing
{
	[TestClass]
	public class ComparerTest
	{
		#region Methods

		[TestMethod]
		public void CompareRegardingNull_IfBothParametersAreNull_ShouldReturnZero()
		{
			Assert.AreEqual(0, this.CreateComparer().CompareRegardingNull(null, null));
			Assert.AreEqual(0, this.CreateComparer(false).CompareRegardingNull(null, null));
			Assert.AreEqual(0, this.CreateComparer(true).CompareRegardingNull(null, null));
		}

		[TestMethod]
		public void CompareRegardingNull_IfFirstParametersIsNotNullAndSecondParameterIsNullAndNullIsGreatestIsFalse_ShouldReturnOne()
		{
			Assert.AreEqual(1, this.CreateComparer(false).CompareRegardingNull(new object(), null));
		}

		[TestMethod]
		public void CompareRegardingNull_IfFirstParametersIsNotNullAndSecondParameterIsNullAndNullIsGreatestIsTrue_ShouldReturnMinusOne()
		{
			Assert.AreEqual(-1, this.CreateComparer(true).CompareRegardingNull(new object(), null));
		}

		[TestMethod]
		public void CompareRegardingNull_IfFirstParametersIsNullAndSecondParameterIsNotNullAndNullIsGreatestIsFalse_ShouldReturnMinusOne()
		{
			Assert.AreEqual(-1, this.CreateComparer(false).CompareRegardingNull(null, new object()));
		}

		[TestMethod]
		public void CompareRegardingNull_IfFirstParametersIsNullAndSecondParameterIsNotNullAndNullIsGreatestIsTrue_ShouldReturnOne()
		{
			Assert.AreEqual(1, this.CreateComparer(true).CompareRegardingNull(null, new object()));
		}

		[TestMethod]
		public void CompareRegardingNull_IfNoParameterIsNull_ShouldReturnNull()
		{
			Assert.IsNull(this.CreateComparer().CompareRegardingNull(new object(), new object()));
			Assert.IsNull(this.CreateComparer(false).CompareRegardingNull(new object(), new object()));
			Assert.IsNull(this.CreateComparer(true).CompareRegardingNull(new object(), new object()));
		}

		protected internal virtual Comparer CreateComparer()
		{
			return new Mock<Comparer> {CallBase = true}.Object;
		}

		protected internal virtual Comparer CreateComparer(bool nullIsGreatest)
		{
			var comparer = this.CreateComparer();

			comparer.NullIsGreatest = nullIsGreatest;

			return comparer;
		}

		[TestMethod]
		public void NullIsGreatest_ShouldReturnFalseByDefault()
		{
			Assert.IsFalse(this.CreateComparer().NullIsGreatest);
		}

		#endregion
	}
}