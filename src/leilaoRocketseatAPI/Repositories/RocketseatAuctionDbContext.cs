using leilaoRocketseatAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace leilaoRocketseatAPI.Repositories
{
    public class RocketseatAuctionDbContext : DbContext
    {
        public RocketseatAuctionDbContext(DbContextOptions options) : base(options) { } //instancia o Options Dbcontext do program 
        public DbSet<Auction> Auctions { get; set; }    
        public DbSet<User> Users { get; set; }  
        public DbSet<Offer> Offers { get; set; }  
      
    }

    /*
 * 
 * public RocketseatAuctionDbContext(DbContextOptions options) : base(options) { } //instancia o Options Dbcontext do program
 * 
 * 
 builder.Services.AddDbContext<RocketseatAuctionDbContext>(options => { 
options.UseSqlite(@"Data Source=C:\\Users\\Mikaio Yamada\\source\\repos\\LeilaoRocketseat\\DB\\leilaoDbNLW.db"); 
});
*/

}
