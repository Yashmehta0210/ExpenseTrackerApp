using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ExpenseLayer
{
    public class ExpenseLayerBusiness
    {
        public void etAddUser(UserEntity userEntity)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userEntity.UserName);
                cmd.Parameters.AddWithValue("@Email", userEntity.Email);
                cmd.Parameters.AddWithValue("@Password", userEntity.Password);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public bool etLoginUser(string Email, string Password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LoginUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int GetUser(string email)
        {
            int id = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("etGetUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        id = Convert.ToInt32(rdr["Id"]);


                    }
                }
            }
            return id;
        }
        public IEnumerable<CategoryEntity> categories
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;
                List<CategoryEntity> categoryEntities = new List<CategoryEntity>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllCategories", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CategoryEntity category = new CategoryEntity();
                        category.Id = Convert.ToInt32(rdr["Id"]);
                        category.CategoryName = rdr["CategoryName"].ToString();
                        category.ExpenseLimit = Convert.ToInt32(rdr["ExpenseLimit"]);
                        categoryEntities.Add(category);

                    }
                    return (categoryEntities);
                }
            }
        }
        public void AddCategory(CategoryEntity category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("etAddCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@ExpenseLimit", category.ExpenseLimit);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateCategory(CategoryEntity category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("etUpdateCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", category.Id);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@ExpenseLimit", category.ExpenseLimit);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCategory(int cid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("etDeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", cid);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddExpense(ExpenseEntity expense)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("etAddExpense", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", expense.Title);

                cmd.Parameters.AddWithValue("@DateTime", expense.DateTime);
                cmd.Parameters.AddWithValue("@Id", expense.Id);
                cmd.Parameters.AddWithValue("@ExpenseAmount", expense.ExpenseAmount);
                cmd.Parameters.AddWithValue("@Description", expense.Description);
                cmd.Parameters.AddWithValue("@UserId", expense.UserId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateExpense(String email, ExpenseEntity expense)
        {
            int id = GetUser(email);
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("etUpdateExpense", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ExpenseId", expense.ExpenseId);
                cmd.Parameters.AddWithValue("@Title", expense.Title);
                cmd.Parameters.AddWithValue("@DateTime", expense.DateTime);
                cmd.Parameters.AddWithValue("@Id", expense.Id);
                cmd.Parameters.AddWithValue("@ExpenseAmount", expense.ExpenseAmount);
                cmd.Parameters.AddWithValue("@Description", expense.Description);
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public IEnumerable<ExpenseEntity> DisplayExpense(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;
            List<ExpenseEntity> expenseEntities = new List<ExpenseEntity>();
            int id = GetUser(email);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ExpenseEntity entity = new ExpenseEntity();
                    entity.ExpenseId = Convert.ToInt32(rdr["ExpenseId"]);
                    entity.Title = rdr["Title"].ToString();
                    entity.DateTime = Convert.ToDateTime(rdr["DateTime"]);
                    /* entity.Id = Convert.ToInt32(rdr["Id"]);*/
                    entity.ExpenseAmount = (float)Convert.ToDouble(rdr["ExpenseAmount"]);
                    entity.Description = rdr["Description"].ToString();
                    entity.CategoryName = rdr["CategoryName"].ToString();

                    expenseEntities.Add(entity);
                }
            }
            return expenseEntities;
        }
        public void DeleteExpense(string email, int eid)
        {
            int id = GetUser(email);
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("etDeleteExpense", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExpenseId", eid);
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddLimit(TotalLimitEntity limitEntity)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("etAddTotalLimit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TotalAmount", limitEntity.TotalAmount);
                cmd.Parameters.AddWithValue("@UserId", limitEntity.UserId);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
       
        public float TotalLimits(string email)
        {
                     float TotalLimit = 0;
                    int id = GetUser(email);
                    string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand("GetTotalAmount", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UserId", id);
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                TotalLimit = (float)Convert.ToDouble(rdr["TotalAmount"]);
                            }
                        }
                        return TotalLimit;
            }
        public float ExpenseTotalLimit(string email)
        {
            float ExpenseTotalLimit = 0;
            int id = GetUser(email);
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetExpenseAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ExpenseTotalLimit += (float)Convert.ToDouble(rdr["ExpenseAmount"]);
                }
            }
            return ExpenseTotalLimit;
        }
        public float CategoryLimit(int id)
        {
            float CategoryLimit = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCategoryLimit", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CategoryLimit += (float)Convert.ToDouble(rdr["ExpenseLimit"]);
                }
            }
            return CategoryLimit;
        }
        public float ExpenseCategoryAmount(int cid,string email)
        {
            int uid = GetUser(email);
            float ExpenseCategoryAmount = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerEntities"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetExpenseCategoryAmount", con);
                cmd.Parameters.AddWithValue("@Id", cid);
                cmd.Parameters.AddWithValue("@UserId", uid);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ExpenseCategoryAmount += (float)Convert.ToDouble(rdr["ExpenseAmount"]);
                }

            }
            return ExpenseCategoryAmount;
        }
    }
}
    
