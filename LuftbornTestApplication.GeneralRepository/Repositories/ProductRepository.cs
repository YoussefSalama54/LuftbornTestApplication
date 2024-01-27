using LuftbornTestApplication.Data;
using LuftbornTestApplication.Repositories.HelperModels;
using LuftbornTestApplication.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LuftbornTestApplication.Repositories.Repositories
{
    public class ProductRepository : GeneralRepository<Product>
    {

        public ProductRepository(MarketPlaceContext context) : base(context)
        {

        }
        public IEnumerable<Product> GetMyPostedProducts(string token)
        {
            var sectoken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            IEnumerable<Claim> listofclaims = sectoken.Claims;
            string id = listofclaims.First().Value;
            //return AsQueryable().Include(a => a.OwnedBy).Where(w => w.OwnedById == id);
            return AsQueryable().Where(w => w.OwnedById == id);
        }
        public IEnumerable<Product> GetAllProduct()
        {
            return AsQueryable().ToList();
        }
        public IEnumerable<Product> GetAvailableProducts(string token)
        {
            var sectoken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            IEnumerable<Claim> listofclaims = sectoken.Claims;
            string id = listofclaims.First().Value;
            return AsQueryable().Where(w => w.Availability == true & w.OwnedById !=id ).ToList();
        }
        public Product? GetProduct(int Id)
        {
            return AsQueryable().Where(w => w.Id == Id).FirstOrDefault();
        }
        public APISuccessModel UpdateProduct( ProductViewModel product)
        {

            var sectoken = new JwtSecurityTokenHandler().ReadJwtToken(product.token);
            IEnumerable<Claim> listofclaims = sectoken.Claims;
            string id = listofclaims.First().Value;
            var existingProduct = GetProduct((int)product.Id);
            if (existingProduct.OwnedById != id)
                return new APISuccessModel{message = "The product cant be changed because you do not own this product" , success = false};
            
            if(existingProduct==null)
                return new APISuccessModel { message = "This product doesnt exist", success = false };
            existingProduct.Price = (decimal)product.Price;
           
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            Update(existingProduct);
            return new APISuccessModel { message = "Product updated successfully", success = true };

        }
        public APISuccessModel DeleteProduct(int id)
        {
            var existingProduct = GetProduct(id);
            if (existingProduct == null)
                return new APISuccessModel { message = "This product doesnt exist", success = false };
            Delete(existingProduct);
            return new APISuccessModel { message = "Product deleted successfully", success = true };
        }
        public APISuccessModel CreateProduct(ProductViewModel product)
        {
            var sectoken = new JwtSecurityTokenHandler().ReadJwtToken(product.token);
            IEnumerable<Claim> listofclaims = sectoken.Claims;
            string id = listofclaims.First().Value;
            var newProduct = new Product {
                Name = product.Name,
                Price = (decimal)product.Price,
             
                Availability = true,
                Description = product.Description,
                OwnedById = id
            };
            Insert(newProduct);
            return new APISuccessModel { message = "Product created successfully", success=true };
        }
        public APISuccessModel BuyProduct(BiddingViewModel model ,string id)
        {
            Product product = GetProduct(model.productId);
            if (product == null)
                return new APISuccessModel { message = "this product doesn't exist", success = false };
            if(product.Price > model.price)
                return new APISuccessModel { message = "insufficient balance", success = false };
            product.Availability = false;
            product.OwnedById = id;
            
            Update(product);
            return new APISuccessModel { message = "product purchased successfully", success = true };
        }
        
                    
    }
}


