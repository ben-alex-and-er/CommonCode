using DataAccessors.Extensions;
using DataAccessors.Interfaces;


namespace Unit_Tests.DataAccessors
{
	public class CRUDExtensionTests
	{
		[TestCaseSource(typeof(CRUDExtensionTestCaseSources), nameof(CRUDExtensionTestCaseSources.UpsertTest_2TypesCaseSource))]
		public async Task UpsertTests_2Types(int identifier, int update, bool expectedResult)
		{
			// Arrange
			ICRUD<int, int> fakeCrud = new FakeCRUD();

			// Act
			var result = await fakeCrud.Upsert(identifier, update);

			// Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[TestCaseSource(typeof(CRUDExtensionTestCaseSources), nameof(CRUDExtensionTestCaseSources.UpsertTest_3TypesCaseSource))]
		public async Task UpsertTests_3Types(int identifier, int updateIdentifier, int update, bool expectedResult)
		{
			// Arrange
			ICRUD<int, int, int> fakeCrud = new FakeCRUD();

			// Act
			var result = await fakeCrud.Upsert(identifier, updateIdentifier, update);

			// Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}
	}


	file class FakeCRUD : ICRUD<int, int>, ICRUD<int, int, int>
	{
		async Task<bool> ICreate<int>.Create(int item)
			=> item == 0;

		IQueryable<int> IRead<int>.Read()
		{
			throw new NotImplementedException();
		}

		async Task<bool> IUpdate<int, int>.Update(int identifier, int update)
			=> identifier != 0 && update == 0;

		Task<bool> IDelete<int>.Delete(int item)
		{
			throw new NotImplementedException();
		}
	}
}
