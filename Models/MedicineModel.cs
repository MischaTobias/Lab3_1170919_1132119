using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1170919_1132119.Models
{
    public class MedicineModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string producer { get; set; }
        public double price { get; set; }
        public int stock { get; set; }

        public MedicineModel()
        {
            id = 0;
            name = null;
            description = null;
            producer = null;
            price = 0;
            stock = 0;
        }
    }
}