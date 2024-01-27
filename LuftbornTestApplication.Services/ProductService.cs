using LuftbornTestApplication.Data;
using LuftbornTestApplication.Repositories.HelperModels;
using LuftbornTestApplication.UOW;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LuftbornTestApplication.Services
{
    public class ProductService
    {
        UnitOfWork unitOfWork;

        public ProductService(MarketPlaceContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }
        public IEnumerable<Product> GetMyPostedProducts(string token)
        {
            return this.unitOfWork.Product.GetMyPostedProducts(token);

        }
        public IEnumerable<Product> GetAllProduct()
        {
            return this.unitOfWork.Product.GetAllProduct();
        }
        public IEnumerable<Product> GetAvailableProducts(string token)
        {
            return this.unitOfWork.Product.GetAvailableProducts(token);
        }
        public Product? GetProduct(int Id)
        {
            return this.unitOfWork.Product.GetProduct(Id);
        }
        public APISuccessModel UpdateProduct(ProductViewModel product)
        {
            APISuccessModel result = this.unitOfWork.Product.UpdateProduct(product);
            if (result.success)
                this.unitOfWork.Commit();
            return result;

        }
        public APISuccessModel DeleteProduct(int id)
        {
            var result = this.unitOfWork.Product.DeleteProduct(id);
            if (result.success)
                this.unitOfWork.Commit();
            return result;
        }
        public APISuccessModel CreateProduct(ProductViewModel product)
        {
            var result =  this.unitOfWork.Product.CreateProduct(product);
            if (result.success)
                this.unitOfWork.Commit();
            return result;
        }
        public APISuccessModel BuyProduct(BiddingViewModel model, string id)
        {
            var result = this.unitOfWork.Product.BuyProduct(model, id);
            if (result.success)
                this.unitOfWork.Commit();
            return result;
        }
    }
}