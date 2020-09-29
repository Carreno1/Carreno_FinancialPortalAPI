using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carreno_FinancialPortalAPI.Models
{
    public class Budget
    {

        public int Id { get; set; }
        public int HouseholdId { get; set; }

        public string Name { get; set; }
        public decimal TargetAmount { get; set; }


    }
}