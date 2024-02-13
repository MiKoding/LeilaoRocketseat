using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilaoRocketseatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketAuctionBaseController : ControllerBase //controller criado apra para ser o pai de outros controller e herdar suas propriedade
    {
    }
}
