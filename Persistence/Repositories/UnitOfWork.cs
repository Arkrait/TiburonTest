using System.Threading.Tasks;
using TiburonTest.Domain.Repositories;
using TiburonTest.Persistence.Contexts;

namespace TiburonTest.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}