using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using QuickTypeBowl;

namespace IS7024.Pages
{
    public class HollywoodBowlModel : PageModel
    {
        public string monthfinal { get; set; }

        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string sunJSON = webClient.DownloadString("https://api.sunrise-sunset.org/json?lat=34.1122&lng=118.3391&date=2020-11-02");
                var sun = QuickTypeSun.Sun.FromJson(sunJSON);
                var results = sun.Results.Sunset;
                string resultsString = results;
                string[] vars = resultsString.Split(':');
                var newtime = Convert.ToInt16(vars[0]);
                int realtime = newtime + 9 - 12;
                string itstime = "~" + realtime + ":" + vars[1] + " PM";
                ViewData["sun"] = itstime;


                string jsonString = webClient.DownloadString("https://api.songkick.com/api/3.0/venues/7211/calendar.json?apikey=Y77nbW56nkfpIpw9");
                JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("SongkickSchema.json"));
                JObject jsonObject = JObject.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                //if (jsonObject.IsValid(schema, out validationEvents))
                //{
                    var hBowl = HBowl.FromJson(jsonString);
                    List<Event> events = hBowl.ResultsPage.Results.Event.ToList();
                    ViewData["events"] = events;

                
                }


                

                //}
                //else
                {
                  //  foreach (string evt in validationEvents)
                    {
                    //    Console.WriteLine(evt);
                    }
                    //ViewData["events"] = new List<Event>();
                }

            }
        }
    }
