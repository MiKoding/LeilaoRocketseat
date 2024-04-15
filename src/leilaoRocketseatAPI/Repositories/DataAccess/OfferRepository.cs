using leilaoRocketseatAPI.Contracts;
using leilaoRocketseatAPI.Entities;

namespace leilaoRocketseatAPI.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository  // é enviado para o OfferRepository o Add()
    {
        private readonly RocketseatAuctionDbContext _dbContext;
        public OfferRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;
        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);

            _dbContext.SaveChanges();
        }
    }
}
