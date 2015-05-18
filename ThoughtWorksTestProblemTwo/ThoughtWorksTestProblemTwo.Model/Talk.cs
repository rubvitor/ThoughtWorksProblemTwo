using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThoughtWorksTestProblemTwo.Model
{
    public class Talk
    {
        public string Title { get; set; }
        /// <summary>
        /// Time in minutes
        /// </summary>
        public decimal TimeMinutes { get; set; }

        public string RealTime { get; set; }
    }
}