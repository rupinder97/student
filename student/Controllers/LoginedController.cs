using student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace student.Controllers
{
    public class LoginedController : Controller
    {
        // GET: Logined
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(login_tbl loginModel)
        {

            using (DbModels dbModel = new DbModels())
            {
                var ud = dbModel.login_tbl.Where(x => x.username == loginModel.username && x.password == loginModel.password).FirstOrDefault();
                if (ud == null)
                {
                    ViewBag.SuccessMessage = "Invaild User/Pass";
                }
                else
                {
                    return RedirectToAction("Index", "admission");
                }
            }
            ModelState.Clear();

            return View("Index", new login_tbl());
        }
    }
}