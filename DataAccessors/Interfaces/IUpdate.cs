namespace DataAccessors.Interfaces
{
	/// <summary>
	/// Interface for ICRUD method for updating entries in the database
	/// </summary>
	/// <typeparam name="T">Identifier</typeparam>
	/// <typeparam name="U">Update</typeparam>
	public interface IUpdate<T, U>
	{
		/// <summary>
		/// Updates an existing entry in the database
		/// </summary>
		/// <param name="identifier"></param>
		/// <param name="update"></param>
		/// <returns></returns>
		Task<bool> Update(T identifier, U update);
	}
}
