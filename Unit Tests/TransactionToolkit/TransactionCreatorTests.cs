using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
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
		private TransactionCreator<TestDbContext> transactionCreator;


		[SetUp]
		public void Setup()
		{
			var services = new ServiceCollection();
			services.AddEntityFrameworkInMemoryDatabase();

			var serviceProvider = services.BuildServiceProvider();

			var options = new DbContextOptionsBuilder<TestDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
				.UseInternalServiceProvider(serviceProvider)
				.Options;

			context = new TestDbContext(options);
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
			// Act
			var transaction = ((ITransactionCreator)transactionCreator).CreateTransaction();

			// Assert
			Assert.That(transaction, Is.Not.Null);
			Assert.That(transaction, Is.InstanceOf<IDbContextTransaction>());

			transaction.Dispose();
		}

		[Test]
		public async Task CreateTransactionAsyncTests()
		{
			// Act
			var transaction = await ((ITransactionCreator)transactionCreator).CreateTransactionAsync();

			// Assert
			Assert.That(transaction, Is.Not.Null);
			Assert.That(transaction, Is.InstanceOf<IDbContextTransaction>());

			await transaction.DisposeAsync();
		}
	}
}
