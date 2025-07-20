using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace TransactionToolkit
{
	using Interfaces;


	/// <summary>
	/// Provider for creating transactions
	/// </summary>
	/// <typeparam name="T">Type of DbContext</typeparam>
	public class TransactionCreator<T> : ITransactionCreator where T : DbContext
	{
		private readonly T context;


		/// <summary>
		/// Constructor for <see cref="TransactionCreator{T}"/>
		/// </summary>
		/// <param name="context"></param>
		public TransactionCreator(T context)
		{
			this.context = context;
		}


		IDbContextTransaction ITransactionCreator.CreateTransaction()
			=> context.Database.BeginTransaction();

		Task<IDbContextTransaction> ITransactionCreator.CreateTransactionAsync()
			=> context.Database.BeginTransactionAsync();
	}
}
