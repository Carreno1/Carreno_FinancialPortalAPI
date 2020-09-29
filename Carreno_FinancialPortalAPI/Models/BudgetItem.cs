using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carreno_FinancialPortalAPI.Models
{
    public class BudgetItem
    {
        
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string Name { get; set; }
        

    }
}