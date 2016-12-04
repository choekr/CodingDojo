using Nancy;
namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get("/", args => 
            {
                ViewBag.show = "Data";
                return View["Hello"];                
            });
        }
    }
}