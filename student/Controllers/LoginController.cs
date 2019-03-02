using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using student.Models;
namespace student.Controllers
{
    public class LoginController : Controller
    {
       [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
            login_tbl loginModel = new login_tbl();
            return View(loginModel);
        }
        [HttpPost]
        public ActionResult AddorEdit(login_tbl loginModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.login_tbl.Add(loginModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfully Submited";
            return View("AddorEdit", new login_tbl());
        }
    }
}