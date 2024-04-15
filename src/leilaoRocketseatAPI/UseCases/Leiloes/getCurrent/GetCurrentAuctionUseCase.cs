using leilaoRocketseatAPI.Contracts;
using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace leilaoRocketseatAPI.UseCases.Leiloes.getCurrent
{

    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentAuctionUseCase(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public Auction? Execute()
        {
            return _repository.GetCurrent();     
        }
    }
}
