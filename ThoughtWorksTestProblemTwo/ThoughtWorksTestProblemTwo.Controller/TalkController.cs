using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorksTestProblemTwo.Model;

namespace ThoughtWorksTesteProblemTwo.Controller
{
    public class TalkController
    {
        /// <summary>
        /// Retorna as talks com a combinação mais próxima do "perfeito" para uma determinada sessão
        /// </summary>
        /// <param name="talks"></param>
        /// <param name="track"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public List<Talk> returnTalks(List<Talk> talks, Track track, Session session)
        {
            try
            {
                var media = talks.Average(u => u.TimeMinutes); //Define a media de minutos das talks para criar permutação.
                int numTalks = Decimal.ToInt32(session.TimeSessionMinutes / media); // define o numero de talks que uma permutação deve possuir baseado na média.
                var talksListsPermuted = Util.Permute<Talk>(talks, numTalks); //Função que cria permutação possíveis com as talks para verificar a melhor soma de minutos.

                List<List<Talk>> listsTalksFinal = new List<List<Talk>>();

                //Faz a soma de cada arranjo para descobrir a melhor permutação e retorná-la para o usuário
                //Se não foi possível criar uma permutação faz o cálculo de soma "perfeita" com a lista na forma que ela se encontra
                if (talksListsPermuted != null && talksListsPermuted.Count() > 0)
                {
                    foreach (var talkListPermuted in talksListsPermuted)
                    {
                        var listTalkDefined = DefineTalksList(talks, session, ref listsTalksFinal, talkListPermuted);
                        if (listTalkDefined != null)
                            return listTalkDefined;
                    }
                }
                else
                {
                    var listTalkDefined = DefineTalksList(talks, session, ref listsTalksFinal, talks);
                    if (listTalkDefined != null)
                        return listTalkDefined;
                }

                //Verifica qual tem a melhor soma (maior)
                var maxMinutes = listsTalksFinal.Max(i => i.Sum(j => j.TimeMinutes));
                //Pega esta lista para retornar
                var talksMax = listsTalksFinal.Where(u => u.Sum(a => a.TimeMinutes) == maxMinutes).FirstOrDefault();
                return talksMax;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Define a lista de Talks mais coerentes de acordo com sua soma final
        /// </summary>
        /// <param name="talks"></param>
        /// <param name="session"></param>
        /// <param name="listsTalksFinal"></param>
        /// <param name="talkListPermuted"></param>
        /// <returns></returns>
        private List<Talk> DefineTalksList(List<Talk> talks, Session session, ref List<List<Talk>> listsTalksFinal, IEnumerable<Talk> talkListPermuted)
        {
            var listTalk = new List<Talk>();
            decimal sum = 0;

            foreach (var talkPermuted in talkListPermuted)
            {
                sum = talkPermuted.TimeMinutes;

                //Verifica se esta talk não ultrapassa o valor da sessão
                if (talkPermuted.TimeMinutes < session.TimeSessionMinutes)
                {
                    //Verifica se não é uma talk que não possui tempo previsto
                    if (talkPermuted.TimeMinutes != 0)
                    {
                        listTalk.Add(talkPermuted);

                        //Pega somente as talks que não possuem sequencias iguais a esta talk atual
                        foreach (var talkVerify in talks.Where(u => u != talkPermuted))
                        {
                            //Verifica novamente se não é uma talk que não possui tempo previsto
                            if (talkVerify.TimeMinutes != 0)
                            {
                                //Soma o valor desta talk com o somado até o momento
                                sum = sum + talkVerify.TimeMinutes;
                                //Verifica se é igual ao valor da sessão, se for faz o retorno e finaliza pois achou o tempo "perfeito"
                                if (sum == session.TimeSessionMinutes)
                                {
                                    listTalk.Add(talkVerify);
                                    return listTalk;
                                }
                                else if (sum > session.TimeSessionMinutes) //Se o tempo "estourou" o limite da sessão, então deve-se descartar esta permuta
                                    break;

                                //Se ainda não chegou no limite de sessão e também não é igual ("perfeito") adiciona na lista para posterior validação com as demais
                                listTalk.Add(talkVerify);
                            }
                        }
                    }
                }
                else if (talkPermuted.TimeMinutes == session.TimeSessionMinutes)
                    listTalk.Add(talkPermuted);

                listsTalksFinal.Add(listTalk);
            }

            return null;
        }

        public void DefineRealTimeTalks(ref List<Talk> talks, string sessionTimeIni)
        {
            decimal timeBef = 0;
            string timeRealCur = sessionTimeIni;
            foreach (var talk in talks)
            {
                talk.RealTime = TimeSpan.Parse(timeRealCur).Add(new TimeSpan(0, Convert.ToInt32(timeBef), 0)).ToString();
                timeRealCur = talk.RealTime;
                timeBef = talk.TimeMinutes;
            }
        }
    }
}
