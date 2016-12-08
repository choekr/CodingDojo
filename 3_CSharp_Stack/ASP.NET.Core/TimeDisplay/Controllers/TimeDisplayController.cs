using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace TimeDisplay.Controllers
{
 public class TimeDisplayController : Controller
 {
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        DateTime CurrentTime = DateTime.Now;
        ViewBag.TimeDisplayDate = CurrentTime.ToString("MMMM dd, yyyy");
        ViewBag.TimeDisplayTime = CurrentTime.ToString("hh:mm tt");
        return View("Index");
    }
 }
}