using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Repositories.HelperModels
{
    public class BiddingViewModel
    {
        public string token { get; set; }
        public decimal price { get; set; }
        public string? ownedById { get; set; }
        public int productId { get; set; }

    }
}
