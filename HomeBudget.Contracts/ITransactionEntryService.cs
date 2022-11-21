using HomeBudget.Data;
using HomeBudget.Models.DropDownLists;
using HomeBudget.Models.Transaction;
using System.Web.Mvc;

namespace HomeBudget.Contracts
{
    public interface ITransactionEntryService
    {
        Task<bool> CreateTransactionEntryAsync(TransactionCreate model);
        Task<List<TransactionListItem>> GetAllTransactionEntriesBySourceAccountId(int sourceAccountId);
        void SetUserId(Guid userId);
        List<AccountEntity> GetAccountsDropDown();
    }
}