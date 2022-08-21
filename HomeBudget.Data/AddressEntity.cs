using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Data
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        public int AddressNumber { get; set; }
        public string AddressStreet { get; set; } = "";
        public string AddressStreet2 { get; set; } = "";
        public string City { get; set; } = "";
        [ForeignKey("StateEntity")]
        public int StateId { get; set; }
        public int Zip { get; set; }
    }
}
