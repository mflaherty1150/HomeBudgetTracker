﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Data
{
    public class AccountEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string AccountNumber { get; set; } = String.Empty;
        public Guid OwnerId { get; set; }
        public double InterestRate { get; set; }
        public decimal Balance { get; set; }
        //[ForeignKey("ProviderEntity")]
        //public int ProviderId { get; set; }
    }
}
