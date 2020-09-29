using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carreno_FinancialPortalAPI.Models
{
    public class BankAccount
    {

        public int Id { get; set; }
        public string name { get; set; }
        public decimal Balance { get; set; }
        
        [EnumDataType(typeof(AccountType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountType Type { get; set; }
        public string UserId { get; set; }

    }

    public enum AccountType
    {
        Checkings,

        Savings
    }

}