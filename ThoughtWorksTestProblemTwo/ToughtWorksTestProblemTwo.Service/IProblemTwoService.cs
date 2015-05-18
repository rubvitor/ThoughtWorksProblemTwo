using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ThoughtWorksTestProblemTwo.Model;

namespace ToughtWorksTestProblemTwo.Service
{
    [ServiceContract]
    public interface IProblemTwoService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
                 Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/DefineTracks?talks={talks}&tracks={tracks}")]
        string DefineTracks(string talks, string tracks);
    }
}
