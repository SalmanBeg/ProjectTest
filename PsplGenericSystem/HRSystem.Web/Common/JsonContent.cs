using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Web.Common
{
    public class JsonContent
    {
        public string GetJsonContent(object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            return json;
        }
    }
}