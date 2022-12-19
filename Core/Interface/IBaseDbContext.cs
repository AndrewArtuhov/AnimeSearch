using System.Threading;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IBaseDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancelalationToken);
    }
}
