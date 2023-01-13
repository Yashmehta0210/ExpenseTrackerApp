using ExpenseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExpenseTracker1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        [ActionName("Login")]
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_post(FormCollection formCollection)
        {
            ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
            bool loginExist = expenseLayer.etLoginUser(formCollection["Email"].ToString(), formCollection["Password"].ToString());


            if (loginExist == true)
            {
               
                Response.Write("<script>alert('Login Successful'); </script>");
                Session["Email"] = formCollection["Email"].ToString();
                return RedirectToAction("Create", "Expense");
            }
            else
            {
                Response.Write("<script>alert('User Not Found, Please Signup');</script>");
                return View();
            }

         

        }
        [HttpGet]
        [ActionName("Signup")]
        public ActionResult Signup()
        {
            return View();   
        }

        [HttpPost]
        [ActionName("Signup")]
        public ActionResult Signup_post(FormCollection formCollection) 
        {
            if (ModelState.IsValid == true)
            {
               

                ExpenseLayerBusiness expenseLayer = new ExpenseLayerBusiness();
                UserEntity user = new UserEntity();
                user.UserName = formCollection["UserName"];
                user.Email = formCollection["Email"];
                user.Password = formCollection["Password"];
                expenseLayer.etAddUser(user);
                Response.Write("<script>alert('SignUp Successfull');</script>");

                return RedirectToAction("Login", "User");



            }
           
            return View();

        }
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        
    }
}