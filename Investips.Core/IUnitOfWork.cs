using System.Threading.Tasks;

namespace Investips.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
