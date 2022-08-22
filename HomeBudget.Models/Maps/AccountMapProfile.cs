using AutoMapper;
using HomeBudget.Data;
using HomeBudget.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models.Maps
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<AccountEntity, AccountCreate>();
            CreateMap<AccountEntity, AccountListItem>();
            CreateMap<AccountEntity, AccountDetail>();
            CreateMap<AccountEntity, AccountEdit>();

            CreateMap<AccountCreate, AccountEntity>();
            CreateMap<AccountListItem, AccountEntity>();
            CreateMap<AccountDetail, AccountEntity>();
            CreateMap<AccountEdit, AccountEntity>();
        }
    }
}
