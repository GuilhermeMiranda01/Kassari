using Kassari.Domain.Interfaces;
using KassariV2.Context;

namespace Kassari.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KassariContext _context;
        public UnitOfWork(KassariContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
