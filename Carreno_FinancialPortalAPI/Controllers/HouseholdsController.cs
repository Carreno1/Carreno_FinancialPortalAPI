using Carreno_FinancialPortalAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Carreno_FinancialPortalAPI.Controllers
{
    [RoutePrefix("Api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };


        /// <summary>
        /// Creates new Household.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greeting"></param>
        /// <returns></returns>
        [HttpPost, Route("CreateHousehold")]
        public async Task<int> CreateHousehold(string name, string greeting)
        {
            return await db.CreateHousehold(name, greeting);
        }


        /// <summary>
        /// Gets the household data.
        /// </summary>
        /// <remarks>Retrieve Household specific data by supplying the endpoint with the Primary Key of the Household you are interested in</remarks>
        /// <param name="householdId">The household identifier.</param>
        /// <returns></returns>
        [Route("GetHouseholdData")]
        public async Task<Household> GetHouseholdData(int householdId)
        {
            return await db.GetHouseholdData(householdId);
        }

        /// <summary>
        /// Gets the household data.
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("GetHouseholdData/json")]
        public async Task<IHttpActionResult> GetHouseholdDataAsJson(int householdId)
        {
            var json = JsonConvert.SerializeObject(await db.GetHouseholdData(householdId));
            return Ok(json);
        }







    }
}
