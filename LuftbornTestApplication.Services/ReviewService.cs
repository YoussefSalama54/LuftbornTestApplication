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
    public class ReviewService
    {
        UnitOfWork unitOfWork;

        public ReviewService(MarketPlaceContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return this.unitOfWork.Review.GetAllReviews();
        }
        public IEnumerable<Review> GetMyReviews(string token)
        {
            
            return this.unitOfWork.Review.GetMyReviews(token);
        }
        public IEnumerable<Review> GetSpecificReview(string? userId)
        {
            return this.unitOfWork.Review.GetSpecificReview(userId);
        }
        public APISuccessModel PostReview(ReviewViewModel review)
        {
            APISuccessModel result = this.unitOfWork.Review.PostReview(review);
            this.unitOfWork.Commit();
            return result;
            
        }
    }
}
