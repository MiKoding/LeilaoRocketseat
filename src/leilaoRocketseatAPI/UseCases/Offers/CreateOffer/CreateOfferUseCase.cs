using leilaoRocketseatAPI.Communication.Requests;
using leilaoRocketseatAPI.Contracts;
using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Services;

namespace leilaoRocketseatAPI.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;
        private readonly IOfferRepository _repository;

        public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository offerRepository) { _loggedUser = loggedUser; _repository = offerRepository; } // construtor para chamada de repositório

        public int Execute(int itemId, RequestCreateOfferJSON request)
        {
  
            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,
            };
          
            _repository.Add(offer);

            return offer.Id;  
        }
    }
}
