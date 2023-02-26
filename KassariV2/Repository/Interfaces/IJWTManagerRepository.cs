using KassariV2.Models;

namespace KassariV2.Repository.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
