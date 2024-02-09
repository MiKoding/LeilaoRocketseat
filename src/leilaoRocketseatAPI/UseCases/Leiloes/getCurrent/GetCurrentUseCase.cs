using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace leilaoRocketseatAPI.UseCases.Leiloes.getCurrent
{
    public class GetCurrentUseCase
    {
        public Auction? Execute()
        {
            var repository = new RocketseatAuctionDbContext();

            var today = new DateTime(2024,01,25);

            return  repository
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
