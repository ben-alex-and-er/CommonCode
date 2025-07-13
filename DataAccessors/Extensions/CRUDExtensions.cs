namespace DataAccessors.Extensions
{
	using Interfaces;


	public static class CRUDExtensions
	{
		public static async Task<bool> Upsert<T, U>(
			this ICRUD<T, U> crud,
			T identifier,
			U update)
		{
			var create = await crud.Create(identifier);

			return create || await crud.Update(identifier, update);
		}

		public static async Task<bool> Upsert<T, U, V>(
			this ICRUD<T, U, V> crud,
			T identifier,
			U updateIdentifier,
			V update)
		{
			var create = await crud.Create(identifier);

			return create || await crud.Update(updateIdentifier, update);
		}
	}
}
