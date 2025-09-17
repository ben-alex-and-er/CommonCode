using Microsoft.EntityFrameworkCore;
using System.Collections;
using TestRig.Extensions;


namespace Unit_Tests.TestRig
{
	public class EFTestQueryableExtensionsTests
	{
		private readonly List<int> numbers = [1, 2, 3, 4, 5];


		[Test]
		public void AsEFTestQueryable_Test()
		{
			// Arrange/Act
			var queryable = numbers.AsEFTestQueryable();

			Assert.That(queryable, Is.Not.Null);
			Assert.That(queryable, Is.AssignableTo<IQueryable<int>>());
		}

		[Test]
		public void AsEFTestQueryable_ElementTypeTest()
		{
			// Arrange
			var queryable = numbers.AsEFTestQueryable();

			// Act
			var result = queryable.ElementType;

			// Assert
			Assert.That(result, Is.EqualTo(typeof(int)));
		}

		[Test]
		public void AsEFTestQueryable_GetEnumeratorTest()
		{
			// Arrange
			var queryable = numbers.AsEFTestQueryable();
			var result = new List<int>();

			// Act
			var enumerator = ((IEnumerable)queryable).GetEnumerator();

			while (enumerator.MoveNext())
			{
				result.Add((int)enumerator.Current!);
			}

			// Assert
			Assert.That(result, Is.EquivalentTo(numbers));
		}


		[Test]
		public void AsEFTestQueryable_LINQTest()
		{
			// Arrange
			var queryable = numbers.AsEFTestQueryable();

			// Act
			var result = queryable
				.Where(x => x % 2 == 0)
				.Select(x => (uint)x)
				.ToList();

			// Assert
			Assert.That(result, Is.EquivalentTo([2, 4]));
		}

		[Test]
		public async Task AsEFTestQueryable_ToListAsyncTest()
		{
			// Arrange
			var queryable = numbers.AsEFTestQueryable();

			// Act
			var result = await queryable.ToListAsync();

			// Assert
			Assert.That(result, Is.EquivalentTo(numbers));
		}

		[Test]
		public async Task AsEFTestQueryable_FirstOrDefaultAsyncTest()
		{
			// Arrange
			var queryable = numbers.AsEFTestQueryable();

			// Act
			var result = await queryable.FirstOrDefaultAsync();

			// Assert
			Assert.That(result, Is.EqualTo(1));
		}
	}
}
