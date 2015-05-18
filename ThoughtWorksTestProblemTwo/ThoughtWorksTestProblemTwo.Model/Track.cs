using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThoughtWorksTestProblemTwo.Model
{
    public class Track
    {
        public Track()
        {
            Sessions = new List<Session>();
        }

        public string IdTrack { get; set; }
        public int NumberTrack { get; set; }
        /// <summary>
        /// Total Time in minutes of the track
        /// </summary>
        public decimal TimeMinutesTotal
        {
            get
            {
                return Sessions.Sum(u => u.TimeSessionMinutes);
            }
        }

        public List<Session> Sessions { get; set; }
    }
}