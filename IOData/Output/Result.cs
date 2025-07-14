namespace IOData.Output
{
	/// <summary>
	/// A generic result wrapper containing a status and an optional value
	/// </summary>
	/// <typeparam name="T">An <see cref="Enum"/> type representing the status of the result</typeparam>
	/// <typeparam name="U">The type of the result value</typeparam>
	public class Result<T, U> where T : Enum
	{
		/// <summary>
		/// The status indicating the outcome of the operation
		/// </summary>
		public T Status { get; }

		/// <summary>
		/// Optional value associated with the result
		/// </summary>
		public U? Value { get; }


		/// <summary>
		/// Constructor for <see cref="Result{T, U}"/>.
		/// </summary>
		/// <param name="status">The status indicating the outcome of the operation</param>
		/// <param name="value">The optional value associated with the result</param>
		public Result(T status, U? value = default)
		{
			Status = status;
			Value = value;
		}
	}

}
