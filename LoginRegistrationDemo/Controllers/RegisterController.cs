using LoginRegistrationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginRegistrationDemo.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult Profilepage()
        {
            if (Session["UserName"] != null && Session["Password"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }


        [HttpPost]
        public ActionResult SaveData(User model)
        {
            var existingUser = (List<User>)System.Web.HttpContext.Current.Application["userList"];
            var validatedUser = existingUser.Where(x => x.UserName == model.UserName).FirstOrDefault();

            if (validatedUser == null)
            {
                if (ModelState.IsValid)
                {
                    System.Web.HttpContext.Current.Application.Lock();
                    ((List<User>)System.Web.HttpContext.Current.Application["userList"]).Add(model);
                    System.Web.HttpContext.Current.Application.UnLock();
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            } 
            else if (validatedUser.UserName == model.UserName)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return View();
        }   

     
        
        [HttpPost]
        public ActionResult Login(User model)
        {
            var userVariable = (List<User>)System.Web.HttpContext.Current.Application["userList"];
            var validatedUser = userVariable.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
            if (validatedUser != null)
            {
                Session["UserName"] = validatedUser.UserName.ToString();
                Session["Password"] = validatedUser.Password.ToString();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
                
                return Json(false, JsonRequestBehavior.AllowGet);
             
        }

    }
}