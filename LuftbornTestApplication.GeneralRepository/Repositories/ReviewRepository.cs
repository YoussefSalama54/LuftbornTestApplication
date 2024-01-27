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
    public class ReviewRepository:GeneralRepository<Review>
    {
        public ReviewRepository(MarketPlaceContext context) : base(context)
        {

        }
        public IEnumerable<Review> GetAllReviews()
        {
            return AsQueryable().ToList();
        }
        public IEnumerable<Review> GetMyReviews(string token)
        {
            var sectoken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            IEnumerable<Claim> listofclaims = sectoken.Claims;
            string id = listofclaims.First().Value;
            //return AsQueryable().Include(a => a.OwnedBy).Where(w => w.OwnedById == id);
            return AsQueryable().Where(w => w.ProductOwnerID == id);
        }
        public IEnumerable<Review> GetSpecificReview(string? userId)
        {
            return AsQueryable().Where(w => w.ProductOwnerID == userId);
        }
        public APISuccessModel PostReview(ReviewViewModel review)
        {
            var sectoken = new JwtSecurityTokenHandler().ReadJwtToken(review.token);
            IEnumerable<Claim> listofclaims = sectoken.Claims;
            string id = listofclaims.First().Value;
            Insert(new Review
            {
                Comment = review.Comment,
                ProductOwnerID = review.ProductOwnerID,
                ReviewerID = id,
                Stars = review.Stars,
            });

            return new APISuccessModel { message = "Review posted successfully", success = true };
        }
    }
}
