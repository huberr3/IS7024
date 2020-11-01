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
                var ludlow = Ludlow.FromJson(jsonString);
                ViewData["Ludlow"] = ludlow;
                                
            }
        }
    }
}
