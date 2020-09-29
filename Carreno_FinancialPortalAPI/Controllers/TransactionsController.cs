using Carreno_FinancialPortalAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Carreno_FinancialPortalAPI.Controllers
{

    [RoutePrefix("Api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Creates and adds a new transaction.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="categoryItemId"></param>
        /// <param name="ownerId"></param>
        /// <param name="amount"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        [Route("AddTransaction")]
        public async Task<int> AddTransaction(TransactionType type, BankAccount id, int categoryItemId, string ownerId, decimal amount, string memo)
        {
            return await db.AddTransaction(type, id, categoryItemId, ownerId, amount, memo);
        }


        /// <summary>
        /// Gets all transactions for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<Transaction> GetTransactions(int accountId)
        {
            return await db.GetTransactions(accountId);
        }


        /// <summary>
        /// Gets a specific transaction and its details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<IHttpActionResult> GetTransactionDetails(int id)
        {
            var data = await db.GetTransactionDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });

        }

        /// <summary>
        /// Deletes a transaction.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteTransaction")]
        public IHttpActionResult DeleteTransaction(int Id)
        {
            return Ok(db.DeleteTransaction(Id));
        }

    }
}
