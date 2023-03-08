using KassariV2.Entities;

namespace KassariV2.Repository.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
