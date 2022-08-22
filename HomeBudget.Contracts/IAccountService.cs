using HomeBudget.Models.Account;

namespace HomeBudget.Contracts
{
    public interface IAccountService
    {
        Task<bool> CreateAccountAsync(AccountCreate model);
        Task<bool> DeleteAccountAsync(int AccountId);
        Task<AccountDetail> GetAccountByIdAsync(int id);
        Task<List<AccountListItem>> GetAllAccountsAsync();
        Task<bool> UpdateAccountAsync(AccountEdit model);
        void SetUserId(Guid userId);
    }
}