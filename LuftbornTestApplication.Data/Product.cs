using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { set;  get; }
        public string? Description { set; get; }
        public decimal Price { set; get; }
        public DateTime PostingDate { set; get; } = DateTime.Now;
        [ForeignKey("OwnedBy")]
        public string? OwnedById { set; get; }
        public virtual MarketPlaceUser OwnedBy { set; get; }
        public bool Availability { set; get; } = true;
        
       
        public string pictureUrl { set; get; } = "../public/products/productimage3.jpg";


    }
}
