using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace TestRig.Data
{
	/// <summary>
	/// <see cref="IAsyncQueryProvider"/> to mimic Entity Framework <see cref="IAsyncQueryProvider"/>
	/// </summary>
	internal class EFTestQueryProvider : IAsyncQueryProvider
	{
		private readonly IQueryProvider innerProvider;


		/// <summary>
		/// Constructor for <see cref="EFTestQueryProvider"/>
		/// </summary>
		/// <param name="inner"></param>
		public EFTestQueryProvider(IQueryProvider inner)
		{
			this.innerProvider = inner;
		}


		public IQueryable CreateQuery(Expression expression)
		{
			var elementType = expression.Type.GetGenericArguments()[0];

			var queryableType = typeof(EFTestQueryable<>).MakeGenericType(elementType);

			return (IQueryable)Activator.CreateInstance(queryableType, innerProvider.CreateQuery(expression))!;
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
			=> new EFTestQueryable<TElement>(innerProvider.CreateQuery<TElement>(expression));

		public object? Execute(Expression expression)
			=> innerProvider.Execute(expression);

		public TResult Execute<TResult>(Expression expression)
			=> innerProvider.Execute<TResult>(expression);

		public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
		{
			var result = Execute(expression);

			if (typeof(TResult).IsGenericType && typeof(TResult).GetGenericTypeDefinition() == typeof(Task<>))
			{
				var resultType = typeof(TResult).GetGenericArguments()[0];
				var taskFromResult = typeof(Task)
					.GetMethod(nameof(Task.FromResult))!
					.MakeGenericMethod(resultType);

				return (TResult)taskFromResult.Invoke(null, [result])!;
			}

			return (TResult)result!;
		}
	}
}
