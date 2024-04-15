using leilaoRocketseatAPI.Entities;

namespace leilaoRocketseatAPI.Contracts
{
    public interface IAuctionRepository
    {
        public Auction? GetCurrent();
    }
}
