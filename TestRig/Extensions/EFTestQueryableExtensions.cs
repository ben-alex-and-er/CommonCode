namespace TestRig.Extensions
{
	using Data;


	/// <summary>
	/// Extension methods related to EFTestQueryables
	/// </summary>
	public static class EFTestQueryableExtensions
	{
		/// <summary>
		/// Converts an <see cref="IEnumerable{T}"/> into an <see cref="IQueryable{T}"/> which can be used for testing with EF
		/// </summary>
		/// <typeparam name="T">Type of element in collection</typeparam>
		/// <param name="enumerable">Collection to convert</param>
		/// <returns><see cref="IQueryable{T}"/> of input collection</returns>
		public static IQueryable<T> AsEFTestQueryable<T>(this IEnumerable<T> enumerable)
			=> new EFTestQueryable<T>(enumerable);
	}
}
