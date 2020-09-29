using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Carreno_FinancialPortalAPI.Models
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext()
          : base("ApiConnection")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <param name="type"></param>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="startingBalance"></param>
        /// <param name="lowBalanceLevel"></param>
        /// <returns></returns>
        public async Task<int> AddAccount(int hhId, AccountType type, string ownerId, string name, decimal startingBalance, decimal lowBalanceLevel)
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @HouseholdId, @BankAccountTypeId, @OwnerId, @Name, @StartingBalance, @LowBalanceLevel",
                    new SqlParameter("HouseholdId", hhId),
                    new SqlParameter("BankAccountTypeId", type),
                    new SqlParameter("OwnerId", ownerId),
                    new SqlParameter("Name", name),
                    new SqlParameter("StartingBalance", startingBalance),
                    new SqlParameter("LowBalanceLevel", lowBalanceLevel));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="categoryItemId"></param>
        /// <param name="ownerId"></param>
        /// <param name="amount"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public async Task<int> AddTransaction(TransactionType type, BankAccount id, int categoryItemId, string ownerId, decimal amount, string memo)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @TransactionTypeId, @BankAccountId, @CategoryItemId, @OwnerId, @Amount, @Memo",
                    new SqlParameter("TransactionTypeId", type),
                    new SqlParameter("BankAccountId", id),
                    new SqlParameter("CategoryItemId", categoryItemId),
                    new SqlParameter("OwnerId", ownerId),
                    new SqlParameter("Amount", amount),
                    new SqlParameter("Memo", memo));
               
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="targetAmount"></param>
        /// <returns></returns>
        public async Task<int> AddBudget(int householdId, string name, string description, decimal targetAmount)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @HouseholdId, @Name, @Description, @TargetAmount",
                    new SqlParameter("HouseholdId", householdId),
                    new SqlParameter("Name", name),
                    new SqlParameter("Description", description),
                    new SqlParameter("TargetAmount", targetAmount));
        }

        /// <summary>
        /// Creates a new Household
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greeting"></param>
        /// <returns></returns>
        public async Task<int> CreateHousehold(string name, string greeting)
        {
            return await Database.ExecuteSqlCommandAsync("CreateHousehold @Name, @Greeting",
                    new SqlParameter("Name", name),
                    new SqlParameter("Greeting", greeting));
        }

        /// <summary>
        /// Gets the household data
        /// </summary>
        /// <param name="hhId">The Primary key of the House</param>
        /// <returns>Household Data</returns>
        public async Task<Household> GetHouseholdData(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdData @hhId",
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }


     


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<BankAccount> GetAccounts(int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccounts @hhId",
                    new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BankAccount> GetAccountDetails(int id)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountDetails @Id",
                    new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactions(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @Id",
                    new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetails(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @Id",
                   new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        public async Task<Budget> GetBudgets(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @Id",
                  new SqlParameter("HouseholdId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Budget> GetBudgetDetails(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @Id",
                    new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BudgetItem> GetBudgetItems(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @Id",
                  new SqlParameter("CategoryId", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BudgetItem> GetBudgetItemDetails(int id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @Id",
                  new SqlParameter("Id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteBudget(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudget @Id",
                new SqlParameter("Id", id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteBudgetItem(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetItem @Id",
                new SqlParameter("Id", id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteTransaction(int id)
        {
            return Database.ExecuteSqlCommand("DeleteTransaction @Id",
                new SqlParameter("Id", id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteBankAccount(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBankAccount @Id",
                new SqlParameter("Id", id));
        }

        public System.Data.Entity.DbSet<Carreno_FinancialPortalAPI.Models.Household> Households { get; set; }

        //public async Task<List<PersonalAccount>> GetAccounts(int householdId)
        //{
        //    return await Database.SqlQuery<PersonalAccount>("GetAccountsByHousehold @householdId",
        //        new SqlParameter("householdId", householdId)).FirstOrDefaultAsync();
        //}



    }
}