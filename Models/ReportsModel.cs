using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_5.Models
{
    public class LinqReportModel
    {
        public List<BLL.Model.ReportModel.ReportData> ReportData { get; set; }
        public List<BLL.ShopModel> shops { get; set; }
        public int SelectShop_Id { get; set; }
    }
    public class ExecuteSP
    {
        public List<BLL.Model.ReportModel.SelectDetalName> DetalNames { get; set; }
        public List<BLL.DetalModel> detals;
        public int SelectDetal_Id { get; set; }
    }
}