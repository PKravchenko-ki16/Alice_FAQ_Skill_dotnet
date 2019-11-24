using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Alice.Model
{
    public class FillingAnswers
    {
        DataConnection dataConnection = DataConnection.getDataConnection();

        public List<AnswerManagement> FillingManagement()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataManager))
            {
               return JsonConvert.DeserializeObject<List<AnswerManagement>>(sr.ReadToEnd());
            }
        }

        public List<AnswerStain> FillingStain()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataStain))
            {
                return JsonConvert.DeserializeObject<List<AnswerStain>>(sr.ReadToEnd(), new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                });
            }
        }

        public List<Position> FillingPosition()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataPosition))
            {
                return JsonConvert.DeserializeObject<List<Position>>(sr.ReadToEnd());
            }
        }

        public OldStain FillingOldStain()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataOldStain))
            {
                return JsonConvert.DeserializeObject<OldStain>(sr.ReadToEnd());
            }
        }
    }
}
