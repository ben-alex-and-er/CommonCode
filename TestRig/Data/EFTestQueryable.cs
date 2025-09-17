using System.Collections;
using System.Linq.Expressions;


namespace TestRig.Data
{
	/// <summary>
	/// <see cref="IQueryable{T}"/> to mimic Entity Framework <see cref="IQueryable{T}"/>
	/// </summary>
	/// <typeparam name="T">Type of item in collection</typeparam>
	internal class EFTestQueryable<T> : IOrderedQueryable<T>, IAsyncEnumerable<T>
	{
		private readonly IQueryable<T> innerQueryable;


		public Type ElementType => typeof(T);

		public Expression Expression => innerQueryable.Expression;

		public IQueryProvider Provider => new EFTestQueryProvider(innerQueryable.Provider);


		/// <summary>
		/// Constructor for <see cref="EFTestQueryable{T}"/>
		/// </summary>
		/// <param name="enumerable"></param>
		public EFTestQueryable(IEnumerable<T> enumerable)
		{
			innerQueryable = enumerable.AsQueryable();
		}


		public IEnumerator<T> GetEnumerator()
			=> innerQueryable.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> innerQueryable.GetEnumerator();

		public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
			=> new EFTestAsyncEnumerator<T>(innerQueryable.GetEnumerator());
	}
}
