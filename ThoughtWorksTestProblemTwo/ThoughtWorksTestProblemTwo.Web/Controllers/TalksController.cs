using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using ThoughtWorksTestProblemTwo.Model;

namespace ThoughtWorksTestProblemTwo.Web.Controllers
{
    /// <summary>
    /// API controller to manage talks
    /// </summary>
    public class TalksController : ApiController
    {

        List<Talk> talksData = new List<Talk>()
        {
                new Talk { Title = "Writing Fast Tests Against Enterprise Rails", TimeMinutes = 60 },
                new Talk { Title = "Overdoing it in Python", TimeMinutes = 45 },
                new Talk { Title = "Lua for the Masses", TimeMinutes = 30 },
                new Talk { Title = "Ruby Errors from Mismatched Gem Versions", TimeMinutes = 45 },
                new Talk { Title = "Common Ruby Errors", TimeMinutes = 45 },
                new Talk { Title = "Rails for Python Developers lightning" },
                new Talk { Title = "Communicating Over Distance", TimeMinutes = 60 },
                new Talk { Title = "Accounting-Driven Development", TimeMinutes = 45 },
                new Talk { Title = "Woah", TimeMinutes = 30 },
                new Talk { Title = "Sit Down and Write", TimeMinutes = 30 },
                new Talk { Title = "Pair Programing vs Noise", TimeMinutes = 45 },
                new Talk { Title = "Rails Magic", TimeMinutes = 60 },
                new Talk { Title = "Ruby on Rails: Why We Should Move On", TimeMinutes = 60 },
                new Talk { Title = "Clojure Ate Scala (on my project)", TimeMinutes = 45 },
                new Talk { Title = "Programing in the Boondocks of Seattle", TimeMinutes = 30 },
                new Talk { Title = "Ruby vs. Clojure for Back-End Development", TimeMinutes = 30 },
                new Talk { Title = "Ruby on Rails Legacy App Maintenance", TimeMinutes = 60 },
                new Talk { Title = "A World Without HackerNews", TimeMinutes = 30 },
                new Talk { Title = "User Interface CSS in Rails Apps", TimeMinutes = 30 }
        };

        public IEnumerable<Talk> Get()
        {
            // Return a static list of talks
            return talksData;
        }

        public Talk Put(Talk talk)
        {
            //Update the user
            return talk;
        }
    }
}
