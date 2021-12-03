using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB_5.Controllers
{
    public class ReportsController : Controller
    {
        BLL.Interfaces.IDBCrud dBCrud;
        BLL.Interfaces.IReportService reportService;

        public ReportsController(IDBCrud dBCrud, IReportService reportService)
        {
            this.dBCrud = dBCrud;
            this.reportService = reportService;
        }

        public ActionResult LinqReport()
        {
            return View(new Models.LinqReportModel() { shops = dBCrud.GetShopModels() });
        }

        [HttpPost]
        public ActionResult LinqReport(Models.LinqReportModel model)
        {
            model.ReportData = reportService.reportDatas(model.SelectShop_Id);
            model.shops = dBCrud.GetShopModels();
            return View(model);
        }
        public ActionResult ExecuteSP()
        {
            return View(new Models.ExecuteSP() { detals = dBCrud.GetDetalModels() });
        }
        [HttpPost]
        public ActionResult ExecuteSP(Models.ExecuteSP model)
        {
            model.DetalNames = reportService.ExecuteSP(dBCrud.GetDetal(model.SelectDetal_Id).name);
            model.detals = dBCrud.GetDetalModels();
            return View(model);
        }
    }
}