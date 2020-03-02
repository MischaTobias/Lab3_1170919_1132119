using Lab3_1170919_1132119.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3_1170919_1132119.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Index()
        {
            return View(Storage.Instance.binaryTree.ToList());
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            return View();
        }

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
    }
}
