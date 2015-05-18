using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughtWorksTestProblemTwo.Model
{
    public class Session
    {
        public Session()
        {
            Talks = new List<Talk>();
        }

        public string Id { get; set; }
        public decimal TimeSessionMinutes { get; set; }
        public List<Talk> Talks { get; set; }
        public string TimeIniSession { get; set; }
    }
}
