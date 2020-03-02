using CustomGenerics.Structures;
using Lab3_1170919_1132119.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1170919_1132119.Helpers
{
    public class Storage
    {
        public static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }
        public BinaryTree<Medicine> binaryTree = new BinaryTree<Medicine>();
    }
}