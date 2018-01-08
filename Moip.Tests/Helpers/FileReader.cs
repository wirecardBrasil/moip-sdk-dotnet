using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Tests.Helpers
{
    class FileReader
    {
        public static string readJsonFile(string fileName)
        {

            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\Resources\" + fileName);
            StreamReader file = new StreamReader(filePath);

            string textFromFile = file.ReadToEnd();

            dynamic obj = JsonConvert.DeserializeObject<dynamic>(textFromFile);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}
