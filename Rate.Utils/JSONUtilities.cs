using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Utils
{
    public static class JSONUtilities
    {
        public static object StringToJson(string jsonString)
        {

            return JsonConvert.DeserializeObject<object>(jsonString);
        }
    }
}
