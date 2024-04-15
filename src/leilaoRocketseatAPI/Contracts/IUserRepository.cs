using leilaoRocketseatAPI.Entities;

namespace leilaoRocketseatAPI.Contracts
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);
        User GetUserByEmail(string email);

    }
}
