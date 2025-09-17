namespace DataAccessors.Extensions
{
	using Interfaces;


	/// <summary>
	/// Extension methods for <see cref="ICRUD{T, U}"/> and <see cref="ICRUD{T, U, V}"/>
	/// </summary>
	public static class CRUDExtensions
	{
		/// <summary>
		/// Attempts to create or update an entry
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="crud"></param>
		/// <param name="identifier"></param>
		/// <param name="update"></param>
		/// <returns></returns>
		public static async Task<bool> Upsert<T, U>(
			this ICRUD<T, U> crud,
			T identifier,
			U update)
		{
			var create = await crud.Create(identifier);

			return create || await crud.Update(identifier, update);
		}

		/// <summary>
		/// Attempts to create or update an entry
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <typeparam name="V"></typeparam>
		/// <param name="crud"></param>
		/// <param name="identifier"></param>
		/// <param name="updateIdentifier"></param>
		/// <param name="update"></param>
		/// <returns></returns>
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
