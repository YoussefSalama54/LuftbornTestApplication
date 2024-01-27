using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Data
{
    public class Bid
    {
        public int Id { get; set; }
        [ForeignKey("BidderID")]
        public string? BidderID { set; get; }
        public virtual MarketPlaceUser Bidder { set; get; }
        [ForeignKey("SellerID")]
        public string? SellerID { set; get; }
        public virtual MarketPlaceUser Seller { set; get; }
        [ForeignKey("ProductID")]
        public int ProductID { set; get; }
        public virtual Product Product { set; get; }
        public decimal BidValue { set; get; }
        public bool Active { set; get; }
    }
}
