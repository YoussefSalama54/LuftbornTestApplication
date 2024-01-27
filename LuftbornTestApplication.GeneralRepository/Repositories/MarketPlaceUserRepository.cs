using LuftbornTestApplication.Data;
using LuftbornTestApplication.Repositories.HelperModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Repositories.Repositories
{
    public class MarketPlaceUserRepository: GeneralRepository<MarketPlaceUser>
    {
        public MarketPlaceUserRepository(MarketPlaceContext context) : base(context)
        {

        }
        public APISuccessModel UpdateUserBalance(string id, BiddingViewModel model)
        {   
            
            MarketPlaceUser user = AsQueryable().Where(w => w.Id == id).FirstOrDefault();
            if (user == null)
                return new APISuccessModel {message = "this user doesnt exist", success= false };
            if(model.price>user.Balance)
                return new APISuccessModel { message = "balance is not enough", success = false };
            user.Balance = user.Balance - model.price;

            MarketPlaceUser seller = AsQueryable().Where(w => w.Id == model.ownedById).FirstOrDefault();
            seller.Balance = seller.Balance + model.price;    
            Update(user);
            Update(seller);
            return new APISuccessModel { message = "transaction completed", success = true };
        }
        public decimal GetUserBalance(string id)
        {
            MarketPlaceUser user = AsQueryable().Where(w => w.Id == id).FirstOrDefault();
            if(user == null)
                return -1;
            return user.Balance;
        }
    }
}
