using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Enums;
using leilaoRocketseatAPI.UseCases.Leiloes.getCurrent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilaoRocketseatAPI.Controllers
{
    public class LeilaoController : RocketAuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)] // define uma resposta para o tipo de response http
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
        {
            var result = useCase.Execute();

            var item =  result?.Items.First();

            if(result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
