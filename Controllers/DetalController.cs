using LAB_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB_5.Controllers
{
    public class DetalController : Controller
    {
        BLL.Interfaces.IDBCrud dBCrud;
        BLL.Interfaces.IOrderService service;

        public DetalController (BLL.Interfaces.IDBCrud dBCrud, BLL.Interfaces.IOrderService service)
        {
            this.dBCrud = dBCrud;
            this.service = service;
        }
        public ActionResult Index()
        {
            List<BLL.ShopModel> shopModels = dBCrud.GetShopModels();
            var model = new OrderModel() { detals = dBCrud.GetDetalModels().Select(i => new DetalModel(i, shopModels)).ToList(), Order = new BLL.OrderModel()  };
            return View("List", model);
        }
        public ActionResult Edit(int id)
        {
            List<BLL.ShopModel> shops = dBCrud.GetShopModels();
            DetalModel p = new DetalModel(dBCrud.GetDetal(id), shops);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(DetalModel model)
        {
            BLL.DetalModel det = new BLL.DetalModel();
            det.id = model.id;
            det.name = model.name;
            det.cost = model.cost.ToString();
            det.Shop_Id = model.Shop_Id;
            dBCrud.UpdateDetal(det);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DetalModel(dBCrud.GetShopModels()));
        }

        [HttpPost]
        public ActionResult Create(DetalModel model)
        {
            BLL.DetalModel det = new BLL.DetalModel();
            det.name = model.name;
            det.cost = model.cost.ToString();
            det.Shop_Id = model.Shop_Id;

            dBCrud.CreateDetal(det);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            dBCrud.DeleteDetal(id);
            return RedirectToAction("Index");
        }

        public ActionResult CreateOrderDetal (OrderModel model)
        {
            List<BLL.ShopModel> shopModels = dBCrud.GetShopModels();
            model.detals = dBCrud.GetDetalModels().Select(i => new DetalModel(i, shopModels)).ToList();
            return View("BuyDetal", model);
        }
        [HttpPost]
        public ActionResult BuyDetal(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                if (service.CreateOrder(orderModel.Order, orderModel.code))
                    return RedirectToAction("Index");
            }
            List<BLL.ShopModel> shopModels = dBCrud.GetShopModels();
            orderModel.detals = dBCrud.GetDetalModels().Select(i => new DetalModel(i, shopModels)).ToList();
            return View("BuyDetal", orderModel);
        }
    }
}