using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_APITesting_ReqresDemo.Support
{
    internal class PostData
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class Datasend
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}
