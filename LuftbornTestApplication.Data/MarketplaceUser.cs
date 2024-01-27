
using Microsoft.AspNetCore.Identity;

namespace LuftbornTestApplication.Data
{
    public class MarketPlaceUser:IdentityUser
    {
        public decimal Balance { get; set; } = 1000;
    }
}