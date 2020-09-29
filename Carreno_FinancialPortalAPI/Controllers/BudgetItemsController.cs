using Carreno_FinancialPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Carreno_FinancialPortalAPI.Controllers
{

    [RoutePrefix("Api/BudgetItems")]
    public class BudgetItemsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();


        /// <summary>
        /// Gets all budget items for a specific budget.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetBudgetItems")]
        public async Task<BudgetItem> GetBudgetItems(int Id)
        {
            return await db.GetBudgetItems(Id);

        }

        /// <summary>
        /// Gets a specific Budget item and its details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<BudgetItem> GetBudgetItemDetails(int id)
        {
            return await db.GetBudgetItemDetails(id);

        }

        /// <summary>
        /// Deletes a budget item.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBudgetItem")]
        public IHttpActionResult DeleteBudgetItem(int Id)
        {
            return Ok(db.DeleteBudgetItem(Id));
        }
    }
}
