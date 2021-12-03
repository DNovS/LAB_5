using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB_5.Models
{
    public class DetalModel
    {
        public int id { get; set; }

        [DisplayName("Название")]
        [Required]
        public string name { get; set; }

        [DisplayName("Цена")]
        public decimal cost { get; set; }

        public int Shop_Id { get; set; }

        [DisplayName("Производитель")]
        public string Shop_Name { get; set; }

        public List<BLL.ShopModel> shops { get; set; }
        public DetalModel() { }

        public DetalModel(List<BLL.ShopModel> shops)
        {
            this.shops = shops;
        }
        public DetalModel(BLL.DetalModel p, List<BLL.ShopModel> shops)
        {
            id = p.id;
            name = p.name;
            cost = decimal.Parse(p.cost);
            Shop_Id = p.Shop_Id;
            Shop_Name = shops.Where(i => i.id == p.Shop_Id).FirstOrDefault().name;
            this.shops = shops;
        }
    }
}