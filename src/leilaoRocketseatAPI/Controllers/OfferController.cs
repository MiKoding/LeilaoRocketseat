using leilaoRocketseatAPI.Communication.Requests;
using leilaoRocketseatAPI.Filters;
using leilaoRocketseatAPI.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilaoRocketseatAPI.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))] //inicia o filtro para ser acessado
    public class OfferController : RocketAuctionBaseController
    {

        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer([FromRoute] int itemId, 
            [FromBody] RequestCreateOfferJSON request,
            [FromServices] CreateOfferUseCase useCase)
        {     
            var id = useCase.Execute(itemId, request);
            return Created(string.Empty, id);
        }
    }
}
