using LuftbornTestApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Repositories.Repositories
{
    public class BiddingRepository:GeneralRepository<Bid>
    {
        public BiddingRepository(MarketPlaceContext context) : base(context)
        {

        }

    }
}
