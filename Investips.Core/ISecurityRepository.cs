using System.Threading.Tasks;
using Investips.Core.Models;

namespace Investips.Core
{
    public interface ISecurityRepository
    {
        Task<Security> GetSecurity(int id);
        void Add(Security security);
    }
}
