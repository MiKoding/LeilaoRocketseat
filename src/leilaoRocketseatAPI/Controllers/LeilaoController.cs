using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Enums;
using leilaoRocketseatAPI.UseCases.Leiloes.getCurrent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilaoRocketseatAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeilaoController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction()
        {
            var useCase = new GetCurrentUseCase();
            var result = useCase.Execute();

            var item =  result.Items.First();

            if(result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }  
    }
}
