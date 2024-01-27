

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Data
{
    public class MarketPlaceContext: IdentityDbContext
    {
        public MarketPlaceContext(DbContextOptions options): base(options) { }
        

        public DbSet<MarketPlaceUser> MarketPlaceUsers { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
       
    }
}
