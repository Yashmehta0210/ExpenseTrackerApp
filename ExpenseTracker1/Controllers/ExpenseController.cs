using ExpenseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker1.Controllers
{
   /* [Authorize]*/
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Expense_List()
        {
            if (Session["Email"] != null)
            {
                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                List<ExpenseEntity> expenseEntities = expenseLayer.DisplayExpense(Session["Email"].ToString()).ToList();
                return View(expenseEntities);

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
           
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create() 
        {
            if (Session["Email"] != null)
            {
                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                List<CategoryEntity> categorylist = expenseLayer.categories.ToList();
                ViewBag.CategoryList = new SelectList(categorylist, "Id", "CategoryName");
                
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            

        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(FormCollection formCollection)
        {
            
            if (Session["Email"] != null)
            {
                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                List<CategoryEntity> categorylist = expenseLayer.categories.ToList();
                ViewBag.CategoryList = new SelectList(categorylist, "Id", "CategoryName");

               
                float TotalLimit = expenseLayer.TotalLimits(Session["Email"].ToString());
                float TotalExpenseAmount = expenseLayer.ExpenseTotalLimit(Session["Email"].ToString());
                float CategoryLimit = expenseLayer.CategoryLimit(Convert.ToInt32(formCollection["Id"]));
                float ExpenseCategoryAmount = expenseLayer.ExpenseCategoryAmount(Convert.ToInt32(formCollection["Id"]), Session["Email"].ToString());
                if (TotalExpenseAmount < TotalLimit)
                {
                    if(ExpenseCategoryAmount < CategoryLimit)
                    {
                        if (ModelState.IsValid)
                        {
                            ExpenseLayerBusiness business = new ExpenseLayerBusiness();
                            int id = business.GetUser(Session["Email"].ToString());

                            ExpenseEntity expenseEntity = new ExpenseEntity();
                            expenseEntity.Title = formCollection["Title"];
                            expenseEntity.DateTime = Convert.ToDateTime(formCollection["DateTime"]);
                            expenseEntity.Id = (int)Convert.ToInt32(formCollection["Id"]);
                            expenseEntity.ExpenseAmount = (float)Convert.ToDouble(formCollection["ExpenseAmount"]);
                            expenseEntity.Description = formCollection["Description"];
                            expenseEntity.UserId = id;

                            business.AddExpense(expenseEntity);
                            return RedirectToAction("Expense_List");
                        }
                     
                    }
                    else
                    {
                        Response.Write("<script>alert('CategoryAmount is greater than ExpenseLimit')</script>");
                        return View();
                    }

                    
                   

                }
                else
                {
                    Response.Write("<script>alert('ExpenseAmount is greater than TotalLimit')</script>");
                    return View();
                }

                return View();

            }
           
            
            else
            {
                
                return RedirectToAction("Login" , "User");
            }
      
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_get(int eid)
        {
            if (Session["Email"] != null)
            {

                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                List<CategoryEntity> categorylist = expenseLayer.categories.ToList();
                ViewBag.CategoryList = new SelectList(categorylist, "Id", "CategoryName");


                ExpenseLayerBusiness business = new ExpenseLayerBusiness();
                ExpenseEntity expense = new ExpenseEntity();
                expense = business.DisplayExpense(Session["Email"].ToString()).Single(s => s.ExpenseId == eid);
                return View(expense);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
           
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(ExpenseEntity entity)
        {
            if (Session["Email"] != null)
            {
                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                List<CategoryEntity> categorylist = expenseLayer.categories.ToList();
                ViewBag.CategoryList = new SelectList(categorylist, "Id", "CategoryName");

                if (ModelState.IsValid)
                {
                    ExpenseLayerBusiness business = new ExpenseLayerBusiness();

                    business.UpdateExpense(Session["Email"].ToString(), entity);
                    return RedirectToAction("Expense_List");
                }

                return View(entity);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    
        public ActionResult Delete(int eid)
        {
            if (Session["Email"] != null)
            {
                if(ModelState.IsValid)
                {
                    ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                    expenseLayer.DeleteExpense(Session["Email"].ToString(),eid);
                   
                    return RedirectToAction("Expense_List");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            return View();
        }











    }
}