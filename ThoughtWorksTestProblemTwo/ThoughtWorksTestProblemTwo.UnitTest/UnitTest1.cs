using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThoughtWorksTesteProblemTwo.Controller;
using ThoughtWorksTestProblemTwo.Model;
using System.Collections.Generic;
using System.Linq;

namespace ThoughtWorksTestProblemTwoUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                List<Track> tracks = new List<Track>();
                tracks.Add(new Track { NumberTrack = 1, IdTrack = "Track1" });
                tracks[0].Sessions.Add(new Session { Id = "Session1", TimeSessionMinutes = 180 });
                tracks[0].Sessions.Add(new Session { Id = "Session2", TimeSessionMinutes = 240 });

                tracks.Add(new Track { NumberTrack = 2, IdTrack = "Track2" });
                tracks[1].Sessions.Add(new Session { Id = "Session1", TimeSessionMinutes = 180 });
                tracks[1].Sessions.Add(new Session { Id = "Session2", TimeSessionMinutes = 240 });


                List<Talk> talks = new List<Talk>();
                talks.Add(new Talk { Title = "Writing Fast Tests Against Enterprise Rails", TimeMinutes = 60 });
                talks.Add(new Talk { Title = "Overdoing it in Python", TimeMinutes = 45 });
                talks.Add(new Talk { Title = "Lua for the Masses", TimeMinutes = 30 });
                talks.Add(new Talk { Title = "Ruby Errors from Mismatched Gem Versions", TimeMinutes = 45 });
                talks.Add(new Talk { Title = "Common Ruby Errors", TimeMinutes = 45 });
                talks.Add(new Talk { Title = "Rails for Python Developers lightning" });
                talks.Add(new Talk { Title = "Communicating Over Distance", TimeMinutes = 60 });
                talks.Add(new Talk { Title = "Accounting-Driven Development", TimeMinutes = 45 });
                talks.Add(new Talk { Title = "Woah", TimeMinutes = 30 });
                talks.Add(new Talk { Title = "Sit Down and Write", TimeMinutes = 30 });
                talks.Add(new Talk { Title = "Pair Programing vs Noise", TimeMinutes = 45 });
                talks.Add(new Talk { Title = "Rails Magic", TimeMinutes = 60 });
                talks.Add(new Talk { Title = "Ruby on Rails: Why We Should Move On", TimeMinutes = 60 });
                talks.Add(new Talk { Title = "Clojure Ate Scala (on my project)", TimeMinutes = 45 });
                talks.Add(new Talk { Title = "Programing in the Boondocks of Seattle", TimeMinutes = 30 });
                talks.Add(new Talk { Title = "Ruby vs. Clojure for Back-End Development", TimeMinutes = 30 });
                talks.Add(new Talk { Title = "Ruby on Rails Legacy App Maintenance", TimeMinutes = 60 });
                talks.Add(new Talk { Title = "A World Without HackerNews", TimeMinutes = 30 });
                talks.Add(new Talk { Title = "User Interface CSS in Rails Apps", TimeMinutes = 30 });

                var trackController = new TrackController();
                var tracksFinal = trackController.DefineTracks(talks, tracks);
            }
            catch (Exception ex)
            { 
                
            }

        }
    }
}
