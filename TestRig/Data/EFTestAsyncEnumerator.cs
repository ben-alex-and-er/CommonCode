namespace TestRig.Data
{
	/// <summary>
	/// <see cref="IAsyncEnumerator{T}"/> to mimic Entity Framework <see cref="IAsyncEnumerator{T}"/>
	/// </summary>
	internal sealed class EFTestAsyncEnumerator<T> : IAsyncEnumerator<T>
	{
		private readonly IEnumerator<T> innerEnumerator;


		public T Current => innerEnumerator.Current;


		/// <summary>
		/// Constructor for <see cref="EFTestAsyncEnumerator{T}"/>
		/// </summary>
		/// <param name="inner"></param>
		public EFTestAsyncEnumerator(IEnumerator<T> inner)
		{
			this.innerEnumerator = inner;
		}


		public ValueTask DisposeAsync()
		{
			innerEnumerator.Dispose();
			return ValueTask.CompletedTask;
		}

		public ValueTask<bool> MoveNextAsync()
			=> new(innerEnumerator.MoveNext());
	}
}
