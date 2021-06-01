using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace osuTools
{
    namespace Online.ApiV1
    {
        public class QueryResult
        {
            public JArray Results{ get; private set; }
            public QueryResult(JArray jarr)
            {
                Results = jarr;
            }
            public QueryResult()
            {
            }
        }
        public static class OnlineQueryTools
        {
            internal static string DefaultOsuApiKey { get; } = "fa2748650422c84d59e0e1d5021340b6c418f62f";
            public static bool InRange(double max,double min,double value,bool includeEdge=true)
            {
                return !includeEdge ? (value > min && value < max) : (value >= min && value <= max);
            }
            public static QueryResult GetResponse(Uri target)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = target;
                string rslt = client.GetStringAsync(target).Result;
                object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(rslt);
                QueryResult queryResult = null;
                if (obj.GetType() == typeof(JArray))
                {
                    queryResult = new QueryResult((JArray)obj);
                    return queryResult;
                }
                if (obj.GetType() == typeof(JObject))
                {
                    queryResult = new QueryResult();
                    queryResult.Results.Add(obj);
                    return queryResult;
                }
                else
                {
                    queryResult = new QueryResult();
                    return queryResult;
                }
            }
        }
    }
}