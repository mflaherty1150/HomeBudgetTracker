using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models.Place
{
    public class PlaceCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
