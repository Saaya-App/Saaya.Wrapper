using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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