using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1170919_1132119.Models
{
    public class Customer
    {
        public string name { get; set; }
        public string address { get; set; }
        public string nit { get; set; }
        private List<string> medicines { get; set; }
        private int debt { get; set; }

        public Customer()
        {
            name = null;
            address = null;
            nit = null;
            medicines = null;
            debt = 0;
        }

        public void AddToList(string med)
        {
            medicines.Add(med);
        }

        public void SumMoney(int price)
        {
            debt += debt;
        }
    }
}