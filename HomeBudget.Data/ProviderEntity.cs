using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Data
{
    public class ProviderEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public double RoutingNumber { get; set; }
        [ForeignKey("AddressEntity")]
        public int AddressId { get; set; }
        public virtual ICollection<AccountEntity> Accounts { get; set; } = new List<AccountEntity>();
    }
}
