using ExpenseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker1.Controllers
{
    public class TotalLimitController : Controller
    {
        // GET: TotalLimit
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create ()
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
                ExpenseLayerBusiness layerBusiness = new ExpenseLayerBusiness();
                int id = layerBusiness.GetUser(Session["Email"].ToString());

                TotalLimitEntity entity  = new TotalLimitEntity();
                entity.TotalAmount = (float)Convert.ToDouble(formCollection["TotalAmount"]);
                entity.UserId = id;
                layerBusiness.AddLimit(entity);
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

    }
}