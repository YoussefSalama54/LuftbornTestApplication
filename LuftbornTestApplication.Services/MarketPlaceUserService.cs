using LuftbornTestApplication.Data;
using LuftbornTestApplication.Repositories.HelperModels;
using LuftbornTestApplication.UOW;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Services
{
    public class MarketPlaceUserService
    {
        UnitOfWork unitOfWork;

        public MarketPlaceUserService(MarketPlaceContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }
        public APISuccessModel UpdateUserBalance(string id, BiddingViewModel model)
        {

            var result = this.unitOfWork.MarketPlaceUser.UpdateUserBalance(id, model);
            if (result.success)
                this.unitOfWork.Commit();
            return result;
        }
        public decimal CheckUserBalance(string id)
        {
            return this.unitOfWork.MarketPlaceUser.GetUserBalance(id);
        }
    }
}
