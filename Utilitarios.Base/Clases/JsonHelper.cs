using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Utilitarios.Base
{
    public static class JsonHelper
    {
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);           
        }       
    }
}
