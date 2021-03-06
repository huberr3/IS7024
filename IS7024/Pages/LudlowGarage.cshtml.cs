﻿using System;
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
    public class LudlowGarageModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("https://api.songkick.com/api/3.0/venues/62388/calendar.json?apikey=Y77nbW56nkfpIpw9");
                JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("SongkickSchema.json"));
                JObject jsonObject = JObject.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                    var rootObject = RootObject.FromJson(jsonString);
                    List<Event> events = rootObject.ResultsPage.Results.Event.ToList();
              
                {
                    foreach (Event evt in events)
                    {
                        string date = evt.Start.Date.ToString();
                        string[] dars = date.Split('/');
                        string day = dars[1];
                        string month = dars[0];
                        string year = dars[2];
                        string[] year1 = year.Split(' ');
                        string yearclean = year1[0];

                        string sunJSON = webClient.DownloadString("https://api.sunrise-sunset.org/json?lat=34.1122&lng=118.3391&date=" + yearclean + "-" + month + "-" + day);
                        var sun = QuickTypeSun.Sun.FromJson(sunJSON);
                        var results = sun.Results.Sunset;
                        string s = results;
                        string[] vars = s.Split(':');
                        var newtime = Convert.ToInt16(vars[0]);
                        int realtime = newtime + 9 - 12;
                        string itstime = "~" + realtime + ":" + vars[1] + " PM";
                        evt.Sunset = itstime;
                    }
                    
                    ViewData["events"] = events;
                }

            }
        }
    }
}
