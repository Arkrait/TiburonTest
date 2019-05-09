using System.Threading.Tasks;

namespace TiburonTest.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}