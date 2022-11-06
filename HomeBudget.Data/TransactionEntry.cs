using System;
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
        
        [Required]
        public DateTime TransactionDate { get; set; }

        public decimal TransactionAmount { get; set; }

        [ForeignKey(nameof(Account))]
        public int SourceAccountId { get; set; }
        
        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }
        
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        

        public virtual AccountEntity Account { get; set; }
        public virtual PlaceEntity Place { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
