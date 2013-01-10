using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URLAnalyzer
{
    public class URL
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}