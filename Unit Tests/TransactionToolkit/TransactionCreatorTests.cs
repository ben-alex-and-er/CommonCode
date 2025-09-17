using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TestRig.Database;
using TransactionToolkit;
using TransactionToolkit.Interfaces;


namespace Unit_Tests.TransactionToolkit
{
	public class TransactionCreatorTests
	{
		private class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
		{

		}


		private TestDbContext context;
		private ITransactionCreator transactionCreator;


		[SetUp]
		public void Setup()
		{
			context = new MockDbContextFactory<TestDbContext>()
				.CreateDbContext();

			transactionCreator = new TransactionCreator<TestDbContext>(context);
		}

		[TearDown]
		public void Teardown()
		{
			context.Dispose();
		}

		[Test]
		public void CreateTransactionTests()
		{
			// Arrange
			IDbContextTransaction transaction = null;

			// Act/Assert
			Assert.Throws<InvalidOperationException>(() => transaction = transactionCreator.CreateTransaction());

			transaction?.Dispose();
		}

		[Test]
		public void CreateTransactionAsyncTests()
		{
			// Arrange
			IDbContextTransaction transaction = null;

			// Act/Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () => transaction = await transactionCreator.CreateTransactionAsync());

			transaction?.Dispose();
		}
	}
}
