﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Data
{
    public class TransactionEntry
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public int SourceAccountId { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [ForeignKey("PlaceEntit")]
        public int PlaceId { get; set; }
        [ForeignKey("CategoryEntity")]
        public int CategoryId { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
