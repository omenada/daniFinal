using ordermgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ordermgt.Controllers
{
    public class LoginController : Controller
    {
        ordermangementDBEntities db = new ordermangementDBEntities();

        // GET: Login
        public ActionResult Index ()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(usersController objchk)
        {

            if (ModelState.IsValid)
            {
                
                var obj = db.users.Where(a => a.u_username.Equals(objchk.u_username) && a.u_password.Equals(objchk.u_password)).FirstOrDefault();


                if (obj != null)
                {
                    Session["UserID"] = obj.u_id.ToString();
                    Session["Username"] = obj.u_username.ToString();
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "The User or Password is Incorrect");
                }

              
            }
            return View(objchk);
        }
          
    }
}