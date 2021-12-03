using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_5.Models
{
    public class OrderModel
    {
        public string code { get; set; }
        public BLL.OrderModel Order { get; set; }
        public List<DetalModel> detals { get; set; }
    }
}