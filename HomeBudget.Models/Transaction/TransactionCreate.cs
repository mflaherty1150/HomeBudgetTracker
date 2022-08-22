using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models.Transaction
{
    public class TransactionCreate
    {
        public int SourceAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PlaceId { get; set; }
        public int CategoryId { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
