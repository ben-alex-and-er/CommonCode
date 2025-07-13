namespace DataAccessors.Interfaces
{
	/// <summary>
	/// Interface for CRUD methods (Create, Read, Update, Delete) for manipulating entries in the database
	/// </summary>
	/// <typeparam name="T">Identifier</typeparam>
	/// <typeparam name="U">Update</typeparam>
	public interface ICRUD<T, U> : ICreate<T>, IRead<T>, IUpdate<T, U>, IDelete<T>
	{
	}

	/// <summary>
	/// Interface for CRUD methods (Create, Read, Update, Delete) for manipulating entries in the database
	/// </summary>
	/// <typeparam name="T">Entry</typeparam>
	/// <typeparam name="U">UpdateIdentifier</typeparam>
	/// <typeparam name="V">Update</typeparam>
	public interface ICRUD<T, U, V> : ICreate<T>, IRead<T>, IUpdate<U, V>, IDelete<T>
	{
	}
}
