using leilaoRocketseatAPI.Contracts;
using leilaoRocketseatAPI.Entities;

namespace leilaoRocketseatAPI.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _repository;
        public LoggedUser(IHttpContextAccessor httpContextAccessor, IUserRepository repository)
        {
            _contextAccessor = httpContextAccessor;
            _repository = repository;   
        }
        public User User()
        {        
            var token = TokenOnRequest();
            var email = FromBase64String(token);

            return _repository.GetUserByEmail(email);
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
