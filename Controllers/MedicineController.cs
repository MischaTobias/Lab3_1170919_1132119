using Lab3_1170919_1132119.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Lab3_1170919_1132119.Models;
using CustomGenerics.Structures;

namespace Lab3_1170919_1132119.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine/Create
        public ActionResult FileInventoryCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileInventoryCreate(FormCollection collection)
        {
            try
            {
                var path = collection["path"];
                StreamReader streamReader = new StreamReader(path);
                var line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                var medicineData = new List<string>();
                while (line != null)
                {
                    while (line != null)
                    {
                        var comilla = line.IndexOf('"');
                        var coma = line.IndexOf(',');

                        if (coma < comilla)
                        {
                            var data = line.Substring(0, coma);
                            line = line.Remove(0, coma + 1);
                            medicineData.Add(data);
                        }
                        else
                        {
                            if (comilla < 0)
                            {
                                if (line.Contains('$'))
                                {
                                    line = line.Remove(0, 1);
                                }
                                comilla = line.Length;
                                coma = line.IndexOf(',');
                                string data = "";
                                if (coma < 0)
                                {
                                    data = line;
                                    line = null;
                                }
                                else
                                {
                                    data = line.Substring(0, coma);
                                    line = line.Remove(0, coma + 1);
                                }
                                medicineData.Add(data);
                            }
                            else
                            {
                                line = line.Remove(0, 1);
                                comilla = line.IndexOf('"');
                                var data = line.Substring(0, comilla);
                                line = line.Remove(0, comilla + 2);
                                medicineData.Add(data);
                            }
                        }
                    }

                    MedicineModel newMedicine = new MedicineModel
                    {
                        id = int.Parse(medicineData[0]),
                        name = medicineData[1],
                        description = medicineData[2],
                        producer = medicineData[3],
                        price = Convert.ToDouble(medicineData[4]),
                        stock = int.Parse(medicineData[5])
                    };
                    Storage.Instance.medicineList.Add(newMedicine);
                    Medicine medicineNode = new Medicine
                    {
                        id = int.Parse(medicineData[0]),
                        name = medicineData[1],
                        stock = int.Parse(medicineData[5])
                    };
                    Comparison Comparer = BinaryTree<string>.CompareByName;
                    Storage.Instance.binaryTree.AddMedicine(medicineData[1], int.Parse(medicineData[0]));
                    line = streamReader.ReadLine();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CustomerInfo()
        {
            return View();
        }

        public ActionResult ShowMedicines()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerInfo(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var cliente = new Customer()
                {
                    name = collection["name"],
                    nit = collection["nit"],
                    address = collection["address"]
                };
                //donde esta 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public delegate int Comparison(string value1, string value2);

        // POST: Medicine/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //aquel lo tenia super diferente
        // simoncho, por eso te decía que necesitaba que él hiciera el push, para que así tuviéramos al menos algo de lo que él hizo jajaa
        
        public ActionResult Carrito()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Carrito(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var cliente = new Customer()
                {
                    name   =collection["name"]  ,
                    nit    =collection["nit"]   ,
                    address =collection["address"]
                };
                //donde esta 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
    }
}
