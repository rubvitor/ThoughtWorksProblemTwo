using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorksTestProblemTwo.Model;

namespace ThoughtWorksTesteProblemTwo.Controller
{
    public class TrackController
    {
        /// <summary>
        /// Define todas as tracks de acordo com os parâmetros enviados pelo usuário
        /// </summary>
        /// <param name="talks"></param>
        /// <param name="tracks"></param>
        /// <returns></returns>
        public List<Track> DefineTracks(List<Talk> talks, List<Track> tracks)
        {
            TalkController TalkController = new TalkController();
            var numSessions = tracks[0].Sessions.Count - 1;
            int contSession = 0;

            //Define a prioridade de exatidão para as primeiras sessões (pois as ultimas podem ter uma folga antes do networking
            while (contSession <= numSessions)
            {
                foreach (var track in tracks)
                {
                    if (talks.Count > 0)
                    {
                        if (track.Sessions[contSession] != null)
                        {
                            var talksReturned = TalkController.returnTalks(talks, track, track.Sessions[contSession]);

                            if (talksReturned != null && talksReturned.Count > 0)
                            {
                                talksReturned = talksReturned.Distinct().ToList();

                                TalkController.DefineRealTimeTalks(ref talksReturned, track.Sessions[contSession].TimeIniSession);

                                track.Sessions[contSession].Talks = new List<Talk>();
                                track.Sessions[contSession].Talks.AddRange(talksReturned);

                                talks = talks.Where(u => !talksReturned.Any(a => a == u)).Distinct().ToList();
                            }
                        }
                    }
                    else
                        break;
                }

                contSession++;
            }

            //Após o término da definição verifica se sobraram talks (que possuem tempo igual a 0)
            //e lança para o final da ultima sessão da uma track, e depois para a ultima das anteriores.
            if (talks.Count > 0)
            {
                int i = tracks.Count - 1;
                foreach (var lastTalk in talks)
                {
                    if (tracks[i] != null)
                    {
                        if (tracks[i].Sessions.Last() != null)
                            tracks[i].Sessions.Last().Talks.Add(lastTalk);
                    }

                    i--;
                }
            }

            return tracks;
        }
    }
}
