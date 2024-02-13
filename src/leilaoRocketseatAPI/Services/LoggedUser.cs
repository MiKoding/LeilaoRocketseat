using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Repositories;

namespace leilaoRocketseatAPI.Services
{
    public class LoggedUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedUser(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public User User()
        {
            var repository = new RocketseatAuctionDbContext();

            var token = TokenOnRequest();
            var email = FromBase64String(token);

            return repository.Users.First(user => user.Email.Equals(email));
        }

        private string TokenOnRequest()
        {
            var authentication = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
            //Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=  
            return authentication["Bearer ".Length..];// Vai começar na posição 7 "Bearer " e estende a partir
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);


            return System.Text.Encoding.UTF8.GetString(data);

        }
    }
}
