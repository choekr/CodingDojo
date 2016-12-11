// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingDojo.Models;
using quotingDojo.Factory; 

namespace quotingDojo.Controllers
{
    public class QuoteController : Controller
    {
        private readonly quoteFactory quoteFactory;
        public QuoteController()
        {
            quoteFactory = new quoteFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(string InputName, string InputQuote)
        {
            QuoteList NewQuote = new QuoteList
            {
                Name = InputName,
                Quote = InputQuote
            };
            ViewBag.Errors = ModelState.Values;
            
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult quotes(QuoteList NewQuote)
        {
            
            if (ModelState.IsValid)
            {
                quoteFactory.Add(NewQuote);
                return RedirectToAction("quotes");
            }
            else 
            {
                TryValidateModel(NewQuote);
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            ViewBag.Quotes = quoteFactory.FindAll();
            return View("Quotes");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Del(int id)
        {
            quoteFactory.Delete(id);
            return RedirectToAction("Quotes");
        }

        // [HttpGet]
        // [Route("edit/{id}")]
        // public IActionResult Edit(int id)
        // {
        //     Quote 
        //     return View("Edit");
        // }
    }
}
