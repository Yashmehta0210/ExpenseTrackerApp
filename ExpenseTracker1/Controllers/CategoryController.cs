using ExpenseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker1.Controllers
{
   /* [Authorize]*/
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Category_Dashboard()
        {
            if (Session["Email"] != null)
            {
                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                List<CategoryEntity> categorieset = expenseLayer.categories.ToList();
                return View(categorieset);
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
                if (ModelState.IsValid)
                {
                    ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                    CategoryEntity category = new CategoryEntity();
                    UpdateModel<CategoryEntity>(category);
                    expenseLayer.AddCategory(category);
                    return RedirectToAction("Category_Dashboard");

                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_get(int cid)
        {
            if (Session["Email"] != null)
            {
                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                CategoryEntity category = new CategoryEntity();
                category = expenseLayer.categories.Single(s => s.Id == cid);

                return View(category);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
           
            
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(CategoryEntity categoryEntity)
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                    expenseLayer.UpdateCategory(categoryEntity);
                    return RedirectToAction("Category_Dashboard");
                }
                return View(categoryEntity);

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
           
        }
        [HttpGet]
        public ActionResult Delete(int cid) 
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    
                    ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                    expenseLayer.DeleteCategory(cid);
                    
                    return RedirectToAction("Category_Dashboard");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
        }

    }
}