using Kassari.Infrastructure.Repositories;
using KassariV2.Context;
using KassariV2.Entities;

namespace KassariV2.Repository
{
    public class UsersRepository : Repository<Users>
    {
        public UsersRepository(KassariContext dbContext) : base(dbContext)
        {
        }
    }
}
