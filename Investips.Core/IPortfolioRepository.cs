using System.Collections.Generic;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace Investips.Core
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> GetPortfolio(int id, bool includeProps = true);
        Task<List<Portfolio>> GetPortfolios();
        void Add(Portfolio porfolio);
        void Remove(Portfolio porfolio);
    }
}
