using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models.Account
{
    public class AccountCreate
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string AccountNumber { get; set; }
        public Guid OwnerId { get; set; }
        public double InterestRate { get; set; }
        public decimal Balance { get; set; }
        public int ProviderId { get; set; }
    }
}
