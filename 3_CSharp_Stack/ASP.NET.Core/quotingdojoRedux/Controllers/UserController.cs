using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingdojoRedux.Models;
using quotingdojoRedux.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace quotingdojoRedux.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory userFactory;
        public UserController(UserFactory user) {
            userFactory = user;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.RegErrors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
            if(TempData["RegErrors"] != null) 
            {
                ViewBag.RegErrors = TempData["RegErrors"];
            }
            if(TempData["LoginErrors"] != null)
            {
                ViewBag.LoginErrors = TempData["LoginErrors"];
            }
            return View("Login");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User NewUser)
        {
            List<string> RegErrors = new List<string>();
            if(ModelState.IsValid)
            {
                var verifyUser = userFactory.GrabEmail(NewUser.Email);
                if (verifyUser.Email == null)
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                    userFactory.Add(NewUser);
                    var user = userFactory.FindByEmail(NewUser.Email); 
                    HttpContext.Session.SetString("Key", user.id.ToString());               
                    return RedirectToAction("NewQuote", "Quote");
                }
                RegErrors.Add("Email is already in use");
                TempData["RegErrors"] = RegErrors;
                return RedirectToAction("Index");
            }
            else 
            {
                foreach (var error in ModelState.Values)
                {
                    if (error.Errors.Count > 0) 
                    {
                        RegErrors.Add(error.Errors[0].ErrorMessage);
                    }
                }
                TempData["RegErrors"] = RegErrors;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(ReturnUser NewReUser)
        {
            List<string> LoginErrors = new List<string>();
            var user = userFactory.FindByEmail(NewReUser.Email); 
            
            if(ModelState.IsValid)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, NewReUser.Password)) //user.Password must match case with User.cs Model
                {                    
                    HttpContext.Session.SetString("Key", user.id.ToString());      
                    HttpContext.Session.SetString("CurrentUser", user.first_name.ToString() + " " + user.last_name.ToString());   
                    return RedirectToAction("NewQuote", "Quote");
                }
                else 
                {
                    LoginErrors.Add("Username or Password Incorrect");
                    TempData["LoginErrors"] = LoginErrors;
                    return RedirectToAction("Index");
                }
            }
            
            else 
            {
                foreach (var error in ModelState.Values)
                {
                    if (error.Errors.Count>0)
                    {
                        LoginErrors.Add(error.Errors[0].ErrorMessage);
                    }
                }
                TempData["LoginErrors"] = LoginErrors;
            }
            return RedirectToAction("Index");
                
        }

        // [HttpGet]
        // [Route("Success")]
        // public IActionResult Success()
        // {

        //     return View("Quote/Add");
        // }
    }
}