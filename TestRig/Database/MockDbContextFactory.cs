using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace TestRig.Database
{
	/// <summary>
	/// <see cref="IDbContextFactory{TContext}"/> for making a mock <see cref="DbContext"/> for use in testing
	/// </summary>
	/// <typeparam name="T">DbContext type</typeparam>
	public class MockDbContextFactory<T> : IDbContextFactory<T> where T : DbContext
	{
		private readonly string name;



		/// <summary>
		/// Constructor for <see cref="MockDbContextFactory{T}"/>
		/// </summary>
		/// <param name="name">Custom in memory database name - will be random if null</param>
		public MockDbContextFactory(string? name = null)
		{
			this.name = name ?? Guid.NewGuid().ToString();
		}


		/// <summary>
		/// Creates a new test DbContext of type <see cref="T"/>
		/// </summary>
		/// <returns>New created test DbContext</returns>
		public T CreateDbContext()
		{
			var services = new ServiceCollection();
			services.AddEntityFrameworkInMemoryDatabase();

			// Fresh service provider is needed to not use MySQL from RankedContext
			var serviceProvider = services.BuildServiceProvider();

			var options = new DbContextOptionsBuilder<T>()
				.UseInMemoryDatabase(name)
				.UseInternalServiceProvider(serviceProvider)
				.Options;

			return (T)Activator.CreateInstance(typeof(T), options)!;
		}
	}
}
