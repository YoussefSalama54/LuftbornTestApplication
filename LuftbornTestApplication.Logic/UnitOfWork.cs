using LuftbornTestApplication.Data;
using LuftbornTestApplication.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.UOW
{
    public class UnitOfWork
    {
        private readonly MarketPlaceContext dbcontext;
        public UnitOfWork(MarketPlaceContext context)
        {
            dbcontext = context;
        }
        public void Commit()
        {
            dbcontext.SaveChanges();
        }
        #region Product
        ProductRepository product;
        public ProductRepository Product => product ?? (product = new ProductRepository(dbcontext));
        #endregion
        #region Review
        ReviewRepository review;
        public ReviewRepository Review => review ?? (review = new ReviewRepository(dbcontext));
        #endregion
        #region MarketPlaceUser
        MarketPlaceUserRepository marketPlaceUser;
        public MarketPlaceUserRepository MarketPlaceUser => marketPlaceUser ?? (marketPlaceUser = new MarketPlaceUserRepository(dbcontext));
        #endregion

    }
}
