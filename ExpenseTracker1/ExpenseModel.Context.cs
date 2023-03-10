//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseTracker1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExpenseTrackerEntities1 : DbContext
    {
        public ExpenseTrackerEntities1()
            : base("name=ExpenseTrackerEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Expensess> tbl_Expensess { get; set; }
        public virtual DbSet<LimitAmount> LimitAmounts { get; set; }
    
        public virtual int AddUser(string userName, string email, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", userNameParameter, emailParameter, passwordParameter);
        }
    
        public virtual int etAddCategory(string categoryName, Nullable<int> expenseLimit)
        {
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            var expenseLimitParameter = expenseLimit.HasValue ?
                new ObjectParameter("ExpenseLimit", expenseLimit) :
                new ObjectParameter("ExpenseLimit", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("etAddCategory", categoryNameParameter, expenseLimitParameter);
        }
    
        public virtual int etDeleteCategory(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("etDeleteCategory", idParameter);
        }
    
        public virtual int etUpdateCategory(Nullable<int> id, string categoryName, string expenseLimit)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            var expenseLimitParameter = expenseLimit != null ?
                new ObjectParameter("ExpenseLimit", expenseLimit) :
                new ObjectParameter("ExpenseLimit", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("etUpdateCategory", idParameter, categoryNameParameter, expenseLimitParameter);
        }
    
        public virtual ObjectResult<GetAllCategories_Result> GetAllCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCategories_Result>("GetAllCategories");
        }
    
        public virtual ObjectResult<LoginUser_Result> LoginUser(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoginUser_Result>("LoginUser", emailParameter, passwordParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int etAddExpense(string title, Nullable<System.DateTime> dateTime, Nullable<double> expenseAmount, string description, Nullable<int> id, Nullable<int> userId)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var dateTimeParameter = dateTime.HasValue ?
                new ObjectParameter("DateTime", dateTime) :
                new ObjectParameter("DateTime", typeof(System.DateTime));
    
            var expenseAmountParameter = expenseAmount.HasValue ?
                new ObjectParameter("ExpenseAmount", expenseAmount) :
                new ObjectParameter("ExpenseAmount", typeof(double));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("etAddExpense", titleParameter, dateTimeParameter, expenseAmountParameter, descriptionParameter, idParameter, userIdParameter);
        }
    
        public virtual int etUpdateExpense(Nullable<int> expenseId, string title, Nullable<System.DateTime> dateTime, Nullable<int> id, Nullable<double> expenseAmount, string description, Nullable<int> userId)
        {
            var expenseIdParameter = expenseId.HasValue ?
                new ObjectParameter("ExpenseId", expenseId) :
                new ObjectParameter("ExpenseId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var dateTimeParameter = dateTime.HasValue ?
                new ObjectParameter("DateTime", dateTime) :
                new ObjectParameter("DateTime", typeof(System.DateTime));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var expenseAmountParameter = expenseAmount.HasValue ?
                new ObjectParameter("ExpenseAmount", expenseAmount) :
                new ObjectParameter("ExpenseAmount", typeof(double));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("etUpdateExpense", expenseIdParameter, titleParameter, dateTimeParameter, idParameter, expenseAmountParameter, descriptionParameter, userIdParameter);
        }
    
        public virtual ObjectResult<GetAllExpenses_Result> GetAllExpenses(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllExpenses_Result>("GetAllExpenses", userIdParameter);
        }
    
        public virtual ObjectResult<etGetUser_Result> etGetUser(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<etGetUser_Result>("etGetUser", emailParameter);
        }
    
        public virtual ObjectResult<etDeleteExpense_Result> etDeleteExpense(Nullable<int> expenseId, Nullable<int> userId)
        {
            var expenseIdParameter = expenseId.HasValue ?
                new ObjectParameter("ExpenseId", expenseId) :
                new ObjectParameter("ExpenseId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<etDeleteExpense_Result>("etDeleteExpense", expenseIdParameter, userIdParameter);
        }
    
        public virtual int etAddTotalLimit(Nullable<double> totalAmount, Nullable<int> userId)
        {
            var totalAmountParameter = totalAmount.HasValue ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(double));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("etAddTotalLimit", totalAmountParameter, userIdParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> GetExpenseAmount(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetExpenseAmount", userIdParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> GetTotalAmount(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetTotalAmount", userIdParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> GetCategoryLimit(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetCategoryLimit", idParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> GetExpenseCategoryAmount(Nullable<int> id, Nullable<int> userId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetExpenseCategoryAmount", idParameter, userIdParameter);
        }
    }
}
