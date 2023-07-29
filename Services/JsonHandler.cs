using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Saaya.Wrapper.Services
{
    public class JsonHandler
    {
        public JArray ParsedJson(string json)
        {
            if (json == null)
                return new JArray { "Content Empty" };

            var parsed = JsonConvert.DeserializeObject<JArray>(json);
            return parsed;
        }
    }
}