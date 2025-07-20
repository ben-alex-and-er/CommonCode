using Microsoft.EntityFrameworkCore.Storage;


namespace TransactionToolkit.Interfaces
{
	/// <summary>
	/// Provider for creating transactions
	/// </summary>
	public interface ITransactionCreator
	{
		/// <summary>
		/// Creates a new DbContext Transaction
		/// </summary>
		/// <returns>Transaction to commit</returns>
		public IDbContextTransaction CreateTransaction();

		/// <summary>
		/// Creates a new DbContext Transaction Asynchronously
		/// </summary>
		/// <returns>Transaction to commit</returns>
		public Task<IDbContextTransaction> CreateTransactionAsync();
	}
}
