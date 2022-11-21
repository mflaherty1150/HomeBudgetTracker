using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HomeBudget.Models.DropDownLists
{
    public class AccountDropDownModel
    {
        public int SelectedAccountId { get; set; }
        public List<SelectListItem> AccountSelectList { get; set; } = new List<SelectListItem>();
    }
}
