using System;
using Nancy;

namespace GreatNumberGame
{
    public class GNModule : NancyModule
    {
        public GNModule()
        {
            Get("/", args => 
            {
                if (Session["RandomNumber"]==null)
                {    
                    Session["RandomNumber"] = new Random().Next(1,101);
                    Console.WriteLine(Session["RandomNumber"]);
                    Session["Input"] = true;
                    Session["Display"] = false;
                    Session["Reset"] = false;
                    ViewBag.Input = Session["Input"];
                }
                else 
                {
                    ViewBag.Message = Session["message"];
                    ViewBag.Display = Session["Display"];
                    ViewBag.Class = Session["Class"];
                    ViewBag.Input = Session["Input"];
                    ViewBag.Reset = Session["Reset"];
                }
                return View["GreatNumberGame"];
            });

            Post("/process", args =>
            {
                // Things to add:
                // 1. Check if the value is integer
                // 2. Check if the value is null

                // if (User.GetType() != (typeof(int)))
                // {
                //     string Input1 = Request.Form.UserNum;
                //     int User = Int32.Parse(Input1);
                //     Session["Display"] = true;
                //     Session["Class"] = "failOutput";
                //     Session["message"] = "Not a valid entry! Please enter a number between 1 and 100!";
                // }
                // else 

                int User = Request.Form.UserNum;

                if (User<1 || User>100) 
                {
                    Session["Display"] = true;
                    Session["Class"] = "failOutput";
                    Session["message"] = "Not a valid entry! Please enter a number between 1 and 100!";
                }

                else if ((int)Session["RandomNumber"] == (int)User)
                {
                    // Console.WriteLine("Successful");
                    Session["Display"] = true;
                    Session["Class"] = "successOutput";
                    Session["Input"] = false;
                    Session["Reset"] = true;
                    Session["message"] = Session["RandomNumber"] + " was the right number!";
                }
                else if ((int)Session["RandomNumber"] > (int)User)
                {
                    // Console.WriteLine("Too Low!");
                    Session["Display"] = true;
                    Session["Class"] = "failOutput";                                    
                    Session["message"] = "Too Low!";
                }
                else if ((int)Session["RandomNumber"] < (int)User)
                {
                    // Console.WriteLine("Too High!");
                    Session["Display"] = true;
                    Session["Class"] = "failOutput";
                    Session["message"] = "Too High!";
                }
                return Response.AsRedirect("/");
            });
                                             
            Post("/reset", args =>
            {
                Session.DeleteAll(); 
                Console.WriteLine("Reset!");
                return Response.AsRedirect("/");
            });
        }
    }
}