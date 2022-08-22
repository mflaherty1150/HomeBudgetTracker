using AutoMapper;
using HomeBudget.Data;
using HomeBudget.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models.Maps
{
    public class TransactionMapProfile : Profile
    {
        public TransactionMapProfile()
        {
            CreateMap<TransactionEntry, TransactionCreate>();
            CreateMap<TransactionEntry, TransactionListItem>();

            CreateMap<TransactionCreate, TransactionEntry>();
            CreateMap<TransactionListItem, TransactionEntry>();
        }
    }
}
