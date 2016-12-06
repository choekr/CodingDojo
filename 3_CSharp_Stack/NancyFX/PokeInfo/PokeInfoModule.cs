using Nancy;
using System;
using System.Collections.Generic;
using ApiCaller;
using Newtonsoft.Json.Linq;

namespace PokeInfo

{
    public class PokeInfoModule : NancyModule
    {
        public PokeInfoModule()
        {
            Get("/", args =>
            {
                ViewBag.Name = "";
                ViewBag.Type = "";
                ViewBag.Weight = "";
                ViewBag.Height = "";
                
                return View["PokeInfo"];
            });

            Get("/{id}", async args => 
            {
                // string Name = "";
                string Type = "";
                // int Weight = 0;
                // int Height = 0;
                await WebRequest.SendRequest($"http://pokeapi.co/api/v2/pokemon/{args.id}", new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        ViewBag.Name = (string)JsonResponse["name"];
                        
                        JArray type = (JArray)JsonResponse["types"];
                        ViewBag.Type = (object)((JObject)(type[0])["type"])["name"];


                        for (int i=0; i<type.Count; i++)
                        {
                        Console.WriteLine(type[i]);
                        }

                        ViewBag.Weight = (int)(long)JsonResponse["weight"];
                        ViewBag.Height = (int)(long)JsonResponse["height"];
                    }
                ));
                // Console.WriteLine(Name); // bulbasaur
                return View["PokeInfo"];
            });
        }
    }
}