using Microsoft.EntityFrameworkCore;
using TestRig.Extensions;


namespace Unit_Tests.TestRig
{
	public class EFTestQueryableExtensionsTests
	{
		private readonly List<int> numbers = [1, 2, 3, 4, 5];


		[Test]
		public void AsEFTestQueryableTests()
		{
			var queryable = numbers.AsEFTestQueryable();

			Assert.That(queryable, Is.Not.Null);
			Assert.That(queryable, Is.AssignableTo<IQueryable<int>>());
		}

		[Test]
		public void AsEFTestQueryableLINQTests()
		{
			var queryable = numbers.AsEFTestQueryable();

			var evens = queryable
				.Where(x => x % 2 == 0)
				.ToList();

			Assert.That(evens, Is.EquivalentTo([2, 4]));
		}

		[Test]
		public async Task AsEFTestQueryableToListAsyncTests()
		{
			var queryable = numbers.AsEFTestQueryable();

			var result = await queryable.ToListAsync();

			Assert.That(result, Is.EquivalentTo(numbers));
		}

		[Test]
		public async Task AsEFTestQueryableFirstOrDefaultAsyncTests()
		{
			var queryable = numbers.AsEFTestQueryable();

			var first = await queryable.FirstOrDefaultAsync();

			Assert.That(first, Is.EqualTo(1));
		}
	}
}
