using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DersBlogSitesi.Models
{
    public class Makale
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }

        public string link { get; set; }
    }
}
