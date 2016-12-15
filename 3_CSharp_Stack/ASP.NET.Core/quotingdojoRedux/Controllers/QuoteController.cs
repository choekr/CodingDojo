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
    public class QuoteController : Controller
    {   
        private readonly QuoteFactory quoteFactory;
        public QuoteController(QuoteFactory quote) {
            quoteFactory = quote;
        }
        // GET: /Home/
        //Route to Add page
        [HttpGet]
        [Route("Add")]
        public IActionResult NewQuote()
        {
            ViewBag.Errors = new List<string>();
            if (HttpContext.Session.GetString("Key") != null)
            {
                ViewBag.CurrentUser = HttpContext.Session.GetString("CurrentUser");
                if(TempData["Errors"] != null)
                {
                    ViewBag.Errors = TempData["Errors"];
                }
                return View("Add");
            }
            return RedirectToAction("Index", "User");
        }

        //Route to Process a new quote
        [HttpPost]
        [Route("quotes")]
        public IActionResult process_quote(QuoteItem NewQuote)
        {
            List<string> Errors = new List<string>();
            if (HttpContext.Session.GetString("Key") != null) //if the user is logged in
            {
                TryValidateModel(NewQuote);
                if (ModelState.IsValid)
                {
                    NewQuote.user_id = HttpContext.Session.GetString("Key");
                    quoteFactory.Add(NewQuote);
                    return RedirectToAction("Quotes");
                }

                else
                {
                    foreach (var error in ModelState.Values)
                    {
                        if (error.Errors.Count > 0) 
                        {
                            Errors.Add(error.Errors[0].ErrorMessage);
                        }
                    }
                    TempData["Errors"] = Errors;
                    return RedirectToAction("NewQuote");
                }
            }
            return RedirectToAction("Index", "User");
        }

        //List of quotes
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<string> Errors = new List<string>();

            if (HttpContext.Session.GetString("Key") != null)
            {
                ViewBag.Quotes = quoteFactory.QuotesByUserByID();
                ViewBag.User = HttpContext.Session.GetString("Key");
                return View("Quotes");
            }  
            return RedirectToAction("Index", "User");          
        }

        [HttpGet]
        [RouteAttribute("edit/{id}")]
        public IActionResult Edit(int id)
        {
            List<string> Errors = new List<string>();
            if (HttpContext.Session.GetString("Key") != null)
            {
                ViewBag.Errors = Errors;
                ViewBag.CurrentUser = HttpContext.Session.GetString("CurrentUser");                
                ViewBag.Quote = quoteFactory.QuoteById(id);
                ViewBag.EditingId = id;
                if(TempData["Errors"]!=null)
                {
                    ViewBag.Errors = TempData["Errors"];
                }
                return View("Edit");
            }            
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        [RouteAttribute("edit/{id}")]
        public IActionResult ConfirmEdit(QuoteItem EditedQuote, int id)
        {
            List<string> Errors = new List<string>();
            if (HttpContext.Session.GetString("Key") != null)
            {
                TryValidateModel(EditedQuote);
                if (ModelState.IsValid)
                {
                    EditedQuote.user_id = HttpContext.Session.GetString("Key");
                    quoteFactory.Edit(EditedQuote, id);
                    return RedirectToAction("Quotes");        
                }
                else
                {
                    foreach (var error in ModelState.Values)
                    {
                        if(error.Errors.Count > 0)
                        {
                            Errors.Add(error.Errors[0].ErrorMessage);
                        }
                    }
                    TempData["Errors"] = Errors;
                    return RedirectToAction("Edit");                
                }
            }
            return RedirectToAction("Index", "User");    
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Del(int id)
        {
            if (HttpContext.Session.GetString("Key") != null)
            {
                quoteFactory.Delete(id);
                return RedirectToAction("Quotes");
            }            
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }

    }
}
