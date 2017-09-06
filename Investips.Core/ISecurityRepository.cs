using System.Collections.Generic;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace Investips.Core
{
    public interface ISecurityRepository
    {
        Task<Security> GetSecurity(int id);
        void Add(Security security);
        Task<List<Security>> GetSecurities();
        Task<Security> GetSecurityWithStudies(int id);
    }
}
