using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace dojodachi.Controllers
{

    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<dojodachi>("dojodachi") == null)
            {
                var Friend = new dojodachi();
                HttpContext.Session.SetObjectAsJson("dojodachi", Friend);
                TempData["image"] = "http://www.thinkwoof.com/250-wide-images/ready-for-a-dog-jack-russell.jpg";                
            }
            ViewBag.Friend = HttpContext.Session.GetObjectFromJson<dojodachi>("dojodachi");
            ViewBag.Comment = TempData["comment"];
            ViewBag.Image = TempData["image"];
            return View();
        }

        [HttpPost]
        [Route("Process")]
        public IActionResult Feed()
        {
            string Action = this.Request.Form["Action"];
            var Friend = HttpContext.Session.GetObjectFromJson<dojodachi>("dojodachi");
            var Life = Friend.Life();

            if (Life == false)
            {

            }
            if (Action == "Feed")
            {
                if (Friend.Meals > 0)
                {
                    Friend.Feed();
                    if (Friend.Happy == true)
                    {
                        TempData["comment"] = "You have fed your DojoDachi! Fullness +" + Friend.FeedChange + ", Meal -1";
                        TempData["image"] = "http://media3.s-nbcnews.com/j/newscms/2014_15/313491/140409-dog-food-1633_db0d9cb46fce6c6117ea235004445e99.nbcnews-fp-360-360.jpg";
                    }
                    else if (Friend.Happy == false)
                    {
                        TempData["comment"] = "DojoDachi did not like the food! Try again!";
                        TempData["image"] = "http://hellonuzzle-content.s3.amazonaws.com/wp-content/uploads/2016/05/18010125/LazyDog1-300x225.jpg";                                                
                    }
                }
                else 
                {
                    TempData["comment"] = "You do not have enough meals to feed your DojoDachi! Work in order to earn meals.";
                }
            } 
            else if (Action == "Play")
            {
                if (Friend.Energy > 4)
                {
                    Friend.Play();
                    if (Friend.Happy == true)
                    {
                        TempData["comment"] = "You have played with your DojoDachi! Happiness +" + Friend.PlayChange + ", Energy -5";
                        TempData["image"] = "https://d1w116sruyx1mf.cloudfront.net/ee-assets/gsd/funnies/Bulldog.jpg";
                    }
                    else if (Friend.Happy == false)
                    {
                        TempData["comment"] = "DojoDachi doesn't want to play! Try again!";
                        TempData["image"] = "http://hellonuzzle-content.s3.amazonaws.com/wp-content/uploads/2016/05/18010125/LazyDog1-300x225.jpg";                        
                    }
                }
                else 
                {
                    TempData["comment"] = "You do not have enough energy to play with your DojoDachi! You must sleep to restore your energy.";
                    TempData["image"] = "http://norbert34.midiblogs.com/media/01/02/ec318d7e000a8d0be6712b11b5e841bd.jpg";
                }
            }
            else if (Action == "Work")
            {
                if (Friend.Energy >4)
                {
                    Friend.Work();
                    TempData["comment"] = "Wokred to get Meals. +" + Friend.WorkChange + ", Energy -5";
                    TempData["image"] = "http://2s3ygp2ortkl67oy1kogvig4.wpengine.netdna-cdn.com/wp-content/uploads/2015/12/Trippin.jpg";
                }
                else
                {
                    TempData["comment"] = "You do not have enough energy to work! You must sleep to restore your energy.";
                    TempData["image"] = "http://norbert34.midiblogs.com/media/01/02/ec318d7e000a8d0be6712b11b5e841bd.jpg";                    
                }
            }
            else if (Action == "Sleep")
            {
                if (Friend.Fullness > 6 && Friend.Happiness > 6) 
                {
                    Friend.Sleep();
                    TempData["comment"] = "Slept. Energy +15, Fullness -5, Happiness -5";
                    TempData["image"] = "http://itsaglamthing.com/wp-content/uploads/2016/05/icon-sleep.png";

                }
                else if (Friend.Fullness <= 5) 
                {
                    Friend.Sleep();
                    Friend.Dead = true;
                    TempData["comment"] = "Your dojodachi starved to death!";
                }
                else if (Friend.Happiness <=5)
                {
                    Friend.Sleep();
                    Friend.Dead = true;
                    TempData["comment"] = "Your dojodachi died with too much sadness!";
                }
            }
           
            HttpContext.Session.SetObjectAsJson("dojodachi", Friend);
            HttpContext.Session.SetString("comment", (string)TempData["comment"]);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [Route("Reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    public class dojodachi
    {
        Random rnd = new Random();
        public int Fullness = 20;
        public int Happiness = 20;
        public int Meals = 3;
        public int Energy = 50;
        public bool Dead = false;
        public bool Win = false;
        public bool Happy = true;
        public string comment;
        public int FeedChange;
        public int PlayChange;
        public int WorkChange;
        public void Feed()
        {
            int Chance = rnd.Next(0,4); // Create chance (0~3 integer)
            Meals -= 1; //Decrease Meals by 1 each time clicked
            if (Chance != 0) // If Chance is not 0 (75% chance)
            {
                FeedChange = rnd.Next(5,11);
                Fullness += FeedChange;
                Happy = true;
            } 
            else // If Chance is 0 (25% chance) 
            {
                Happy = false;
            }
            Life();
            Finale();
        }
        public void Play()
        {
            int Chance = rnd.Next(0,4);
            Energy -= 5;
            if (Chance != 0) 
            {
                PlayChange = rnd.Next(5,11);
                Happiness += PlayChange;
                Happy = true;
            }
            else
            {
                Happy = false;
            }
            Life();
            Finale();
        }
        public void Work()
        {
            Energy -= 5;
            WorkChange = rnd.Next(1,4);
            Meals += WorkChange;
            Life();
            Finale();
            Happy = true;
        }
        public void Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            Life();
            Finale();
            Happy = true;
        }
        public bool Life()
        {
            if(Fullness <= 0 || Happiness <=0)
            {
                Dead = true;
            }
            return Dead;
        }

        public bool Finale()
        {
            if (Energy > 100 && Fullness > 100 && Happiness > 100)
            {
                Win = true;
            }
            return Win;
        }
    }
}
