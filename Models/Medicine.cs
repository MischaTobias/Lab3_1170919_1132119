using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1170919_1132119.Models
{
    public class Medicine
    {
        public int id { get; set; }
        public string name { get; set; }

        public Medicine()
        {
            id = 0;
            name = null;
        }
    }
}