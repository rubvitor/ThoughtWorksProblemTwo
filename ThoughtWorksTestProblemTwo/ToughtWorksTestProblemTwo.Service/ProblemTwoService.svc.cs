using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ThoughtWorksTesteProblemTwo.Controller;
using ThoughtWorksTestProblemTwo.Model;

namespace ToughtWorksTestProblemTwo.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode
        = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProblemTwoService : IProblemTwoService
    {
        public string DefineTracks(string talks, string tracks)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            var JavaScriptSerializer = new JavaScriptSerializer();
            return JavaScriptSerializer.Serialize(new TrackController().DefineTracks(JavaScriptSerializer.Deserialize<List<Talk>>(talks), JavaScriptSerializer.Deserialize<List<Track>>(tracks)));
        }
    }
}
