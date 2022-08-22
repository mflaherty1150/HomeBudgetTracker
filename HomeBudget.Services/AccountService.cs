using AutoMapper;
using AutoMapper.Configuration.Conventions;
using HomeBudget.Contracts;
using HomeBudget.Data;
using HomeBudget.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private Guid _userId;

        public AccountService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AccountListItem>> GetAllAccountsAsync()
        {
            var accounts = await _context.Accounts
                .Where(x => x.OwnerId == _userId)
                .Select(entity => _mapper.Map<AccountListItem>(entity))
                .ToListAsync();

            return accounts;
        }

        public async Task<AccountDetail> GetAccountByIdAsync(int id)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(entity => entity.Id == id && entity.OwnerId == _userId);

            return account is null ? null : _mapper.Map<AccountDetail>(account);
        }

        public async Task<bool> CreateAccountAsync(AccountCreate model)
        {
            var accountEntity = _mapper.Map<AccountCreate, AccountEntity>(model, opt => opt.AfterMap((src, dest) => dest.OwnerId = _userId));

            _context.Accounts.Add(accountEntity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateAccountAsync(AccountEdit model)
        {
            if (model == null) return false;

            var accountIsUserOwned = await _context.Accounts.AnyAsync(account => account.Id == model.Id && account.OwnerId == _userId);

            //var accountToUpdate = await _context.Accounts.FindAsync(model.Id);

            //if (accountToUpdate.OwnerId != _userId) return false;

            if (!accountIsUserOwned) return false;

            var newAccount = _mapper.Map<AccountEdit, AccountEntity>(model, opt => opt.AfterMap((src, dest) => dest.OwnerId = _userId));

            _context.Entry(newAccount).State = EntityState.Modified;
            _context.Entry(newAccount).Property(e => e.CreationDate).IsModified = false;
            
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAccountAsync(int AccountId)
        {
            var entity = await _context.Accounts.FindAsync(AccountId);
            if (entity?.OwnerId != _userId) return false;

            _context.Accounts.Remove(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public void SetUserId(Guid userId) => _userId = userId;
    }
}
