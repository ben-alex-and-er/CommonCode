namespace DataAccessors.Interfaces
{
	/// <summary>
	/// Interface for ICRUD method for deleting entries from the database
	/// </summary>
	/// <typeparam name="T">Identifier</typeparam>
	public interface IDelete<T>
	{
		/// <summary>
		/// Removes an existing entry from the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Task<bool> Delete(T item);
	}
}
