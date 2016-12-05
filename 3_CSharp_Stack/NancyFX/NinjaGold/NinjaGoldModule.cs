using System;
using Nancy;
using System.Collections.Generic;

namespace NinjaGold
{
    public class NinjaGoldModule : NancyModule
    {
        public static List<string> ActivityLog;
        public NinjaGoldModule()
        {
            Get("/", args => 
            {                
                if (Session["MyGold"] == null && Session["List"] ==null) 
                {
                    ActivityLog = new List<string>(); //Create a new list for Activity Log
                    // ActivityLog.Add(""); //Assign blank string for initial load (gets rid of [ERR!])
                    Session["MyGold"] = 0;
                    // Session["Gold"] = 0;
                    ViewBag.Activities = "";
                    ViewBag.MyGold = Session["MyGold"];   
                }
                else
                {
                    ViewBag.MyGold = Session["MyGold"];
                    ViewBag.ActivityColor = Session["ActivityColor"];
                    ViewBag.ActivityLog = Session["List"];
                    // ViewBag.Activities = Session["Activity"]; //Display individual activity (One at a time)
                    // Console.WriteLine(Session["Activity"]);
                }

                return View["NinjaGold", ActivityLog];
            });

            Post("/process_money", args =>
            {
                string place = this.Request.Form["building"];                
                string time = DateTime.Now.ToString();
                Random rand = new Random();         

                if (place == "Farm")
                {
                    Session["Location"] = place;
                    Session["Gold"] = rand.Next(10, 21);
                }
                else if (place == "Cave")
                {
                    Session["Location"] = place;
                    Session["Gold"] = rand.Next(5,11);
                }
                else if (place == "House")
                {
                    Session["Location"] = place;
                    Session["Gold"] = rand.Next(2,6);
                }
                else if (place == "Casino")
                {
                    Session["Location"] = place;
                    Session["Gold"] = rand.Next(-50, 50);
                }

                if ((int)Session["Gold"] > 0)
                {
                    Session["Activity"] = "<p class = green> Earned " + Session["Gold"] + " golds from the " + Session["Location"] + " (" + time + ") </p>";
                    ActivityLog.Insert(0,(string)Session["Activity"]);   
                    Session["List"] = ActivityLog;  
                }
                else if ((int)Session["Gold"] < 0)
                {
                    // Session["ActivityColor"] = "red";
                    Session["Activity"] = "<p class = red> Entered a Casino and lost " + Session["Gold"] + " golds... Ouch.." + " (" + time + ") </p>";
                    ActivityLog.Insert(0, (string)Session["Activity"]);   
                    Session["List"] = ActivityLog;                                   
                }

                Session["MyGold"] = (int)Session["MyGold"] + (int)Session["Gold"];   
                for (int i=0; i<ActivityLog.Count; i++)
                {
                    Console.WriteLine(ActivityLog[ActivityLog.Count-1]);
                }
                return Response.AsRedirect("/");
            });

            Post("/reset", args =>
            {
                Session.DeleteAll();           
                return Response.AsRedirect("/");
            });
        }
    }
}