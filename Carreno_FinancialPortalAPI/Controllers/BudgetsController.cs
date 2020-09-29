using Carreno_FinancialPortalAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;

namespace Carreno_FinancialPortalAPI.Controllers
{

    [RoutePrefix("Api/Budgets")]
    public class BudgetsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Creates and Adds a new budget to a household.
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="targetAmount"></param>
        /// <returns></returns>
        [HttpPost, Route("AddBudget")]
        public async Task<int> AddBudget(int householdId, string name, string description, decimal targetAmount)
        {
            return await db.AddBudget(householdId, name, description, targetAmount);
        }


        /// <summary>
        /// Gets all budgets present in a household.
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<Budget> GetBudgets(int householdId)
        {
            return await db.GetBudgets(householdId);

        }

        /// <summary>
        /// Gets details for a specific budget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetBudgetDetails")]
        public async Task<IHttpActionResult> GetBudgetDetails(int id)
        {
            var data = await db.GetBudgetDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Deletes a specific budget.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBudget")]
        public IHttpActionResult DeleteBudget(int Id)
        {
            return Ok(db.DeleteBudget(Id));
        }
      
    }

}