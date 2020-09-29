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
    [RoutePrefix("Api/BankAccounts")]
    public class BankAccountsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Adds a new bank account.
        /// </summary>
        /// <param name="hhId"></param>
        /// <param name="type"></param>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="startingBalance"></param>
        /// <param name="lowBalanceLevel"></param>
        /// <returns></returns>
        [HttpPost, Route("AddAccounts")]
        public async Task<int> AddAccount(int hhId, AccountType type, string ownerId, string name, decimal startingBalance, decimal lowBalanceLevel)
        {
            return await db.AddAccount(hhId, type, ownerId, name, startingBalance, lowBalanceLevel);
        }


        /// <summary>
        /// Gets all bank accounts present in a household.
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("GetAccounts")]
        public async Task<BankAccount> GetAccounts(int householdId)
        {
            return await db.GetAccounts(householdId);
        }

        /// <summary>
        /// Gets all details for a specific bank account.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetAccountDetails")]
        public async Task<IHttpActionResult> GetAccountDetails(int id)
        {
            var data = await db.GetAccountDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Deletes a bank account.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBankAccount")]
        public IHttpActionResult DeleteBankAccount(int Id)
        {
            return Ok(db.DeleteBankAccount(Id));
        }
    }
}
