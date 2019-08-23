using ordermgt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ordermgt.Controllers
{
    public class LoginController : Controller
    {
        public object u_username { get; private set; }
        public object u_password { get; private set; }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection objchk)
        {

            //Session["userName"] = collection["userName"].ToString();
            //Session["passWord"] = collection["passWord"].ToString();
            string userNameLOGIN = objchk["u_username"].ToString();
            string passWordLOGIN = objchk["u_password"].ToString();

            SqlConnection connecLOGIN = new SqlConnection();
            connecLOGIN.ConnectionString = "Server = ordermangementDB.mssql.somee.com; Database = ordermangementDB; User Id = omenada_SQLLogin_1;Password = lk2yhqy63m";

            try
            {
                Session["isLogged"] = "false";
                connecLOGIN.Open();
                string queryLogin = "SELECT u_password FROM users WHERE u_username ='" + passWordLOGIN + "';";

                SqlCommand commLOGIN = new SqlCommand(queryLogin, connecLOGIN);
                SqlDataReader ResultOfTheSelect = commLOGIN.ExecuteReader();

                while (ResultOfTheSelect.Read())
                {
                    if (ResultOfTheSelect["password"].ToString() == passWordLOGIN)
                    {
                        Session["isLogged"] = "true";
                        RedirectToAction("Index");
                    }
                    else
                    {
                        Session["isLogged"] = "false";
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connecLOGIN.Close();
            }
            return View();

            //    if (ModelState.IsValid)
            //    {
            //        ordermangementDBEntities db = new ordermangementDBEntities();

            //        var obj = db.users.Where(a => a.u_username.Equals(objchk.u_username) && a.u_password.Equals(objchk.u_password)).FirstOrDefault();


            //        if (obj != null)
            //        {
            //            Session["UserID"] = obj.u_id.ToString();
            //            Session["Username"] = obj.u_username.ToString();
            //            return RedirectToAction("Index", "Home");
            //        }

            //        else
            //        {
            //            ModelState.AddModelError("", "The User or Password is Incorrect");
            //        }


            //    }
            //    return View(objchk);
            //}

        }
    }
}