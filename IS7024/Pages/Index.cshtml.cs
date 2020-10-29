using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using QuickType;

namespace IS7024.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("https://api.songkick.com/api/3.0/venues/62388/calendar.json?apikey=Y77nbW56nkfpIpw9");
                JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("ConcertSchema.json"));
                JObject jsonObject = JObject.Parse(jsonString);
                IList<String> validationEvents = new List<string>();
                if (jsonObject.IsValid(schema, out validationEvents))
                {
                var welcome = Welcome.FromJson(jsonString);
                
                ViewData["Welcome"] = welcome;
                } else
                {
                    foreach(string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                    ViewData["Events"] = new List<Welcome>();
                }
            }
        }
    }
}
