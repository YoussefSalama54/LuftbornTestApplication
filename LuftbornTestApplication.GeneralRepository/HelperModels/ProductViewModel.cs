using LuftbornTestApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Repositories.HelperModels
{
    public class ProductViewModel
    {
        public int? Id { get; set; } 
        public string? Name { set; get; }
        public string? Description { set; get; }
        public decimal? Price { set; get; }
        public DateTime? PostingDate { set; get; }
        public string? OwnedByID { set; get; }
        public bool? Availability { set; get; }
        public decimal? MaxBidBuyout { set; get; }
        public string token { set; get; }

    }
}
