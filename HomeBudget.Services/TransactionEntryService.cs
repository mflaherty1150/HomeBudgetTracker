using AutoMapper;
using HomeBudget.Contracts;
using HomeBudget.Data;
using HomeBudget.Models.Transaction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Services
{
    public class TransactionEntryService : ITransactionEntryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private Guid _userId;

        public TransactionEntryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TransactionListItem>> GetAllTransactionEntriesBySourceAccountId(int sourceAccountId)
        {
            var transactions = await _context.Transactions
                .Where(x => x.SourceAccountId == sourceAccountId)
                .Select(entity => _mapper.Map<TransactionListItem>(entity))
                .ToListAsync();

            return transactions;
        }

        public async Task<bool> CreateTransactionEntryAsync(TransactionCreate model)
        {
            var transactionEntry = _mapper.Map<TransactionCreate, TransactionEntry>(model);

            _context.Transactions.Add(transactionEntry);

            return await _context.SaveChangesAsync() == 1;
        }

        public void SetUserId(Guid userId) => _userId = userId;
    }
}
