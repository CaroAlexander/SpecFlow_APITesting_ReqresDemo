//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SpecFlow_APITesting_ReqresDemo
//{

//    class Datamodel
//    {
//        public string name { get; set; }
//        public string job { get; set; }
//        public object[] addr { get; set; }
//    }

//    class Postalcode
//    {
//        public string code { get; set; }
//        public string sector { get; set; }
//    }


//    internal class Serialize
//    {
//        Datamodel data = new Datamodel()
//        {
//            name = "Alex",
//            job = "QA Engineer",
//            addr = new[] { new Postalcode() { code = "1234", sector = "5678" }, "belgium", "england" }
//        };

//        var dataser = JsonConvert.SerializeObject(data);
//        Console.WriteLine(dataser)

//    }
//}
