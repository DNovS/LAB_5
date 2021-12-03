using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB_5.Controllers
{
    public class OrderController : Controller
    {
        IDBCrud dBCrud;

        public OrderController(IDBCrud dBCrud)
        {
            this.dBCrud = dBCrud;
        }

        public ActionResult Index()
        {
            var items = dBCrud.GetOrderModels();
            return View(items);
        }
        public ActionResult Delete (int id)
        {
            dBCrud.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}