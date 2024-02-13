﻿using leilaoRocketseatAPI.Communication.Requests;
using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Repositories;
using leilaoRocketseatAPI.Services;

namespace leilaoRocketseatAPI.UseCases.Offers.CreateOffer
{    
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;

        public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

        public int Execute(int itemId, RequestCreateOfferJSON request)
        {
            var repository = new RocketseatAuctionDbContext();

            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,
            };
            repository.Offers.Add(offer);
            
           repository.SaveChanges();


            return offer.Id;  
        }
    }
}
