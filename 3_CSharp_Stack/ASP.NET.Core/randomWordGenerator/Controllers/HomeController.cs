using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace randomWordGenerator.Controllers
{
    public class HomeController : Controller
    {
        // public static int Counter = 0; //Using Integer for counter

        private static Random rnd = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 14).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Counter")==null)
            {
                HttpContext.Session.SetInt32("Counter", 0); 
            }
            int Counter = (int)HttpContext.Session.GetInt32("Counter");
            Counter += 1;
            HttpContext.Session.SetInt32("Counter", Counter);
            // Counter += 1; //Using Integer for counter
            string RandomWord = RandomString();
            ViewBag.RandomWord = RandomWord;
            ViewBag.AttemptCounter = HttpContext.Session.GetInt32("Counter");
            return View();
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            // Counter = 0; // Using Integer for counter
            HttpContext.Session.Clear();
            Console.WriteLine("Reset Session");
            return RedirectToAction("Index");
        }
    }
}
