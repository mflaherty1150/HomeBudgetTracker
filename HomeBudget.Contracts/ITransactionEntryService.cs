using HomeBudget.Models.Transaction;

namespace HomeBudget.Contracts
{
    public interface ITransactionEntryService
    {
        Task<bool> CreateTransactionEntryAsync(TransactionCreate model);
        Task<List<TransactionListItem>> GetAllTransactionEntriesBySourceAccountId(int sourceAccountId);
        void SetUserId(Guid userId);
    }
}