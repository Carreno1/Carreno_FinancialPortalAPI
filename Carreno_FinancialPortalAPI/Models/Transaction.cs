using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carreno_FinancialPortalAPI.Models
{
    public class Transaction
    {
          
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public int BankAccountId { get; set; }
        public int? CategoryItemId { get; set; }


        public string OwnerId { get; set; }

        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public DateTime Created { get; set; }

        [EnumDataType(typeof(TransactionType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }

    }

    public enum TransactionType
    {
        Deposit,

        Withdrawal
    }

}