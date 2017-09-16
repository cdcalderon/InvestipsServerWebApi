using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace Investips.Core
{
    public interface IChartRepository
    {
        Task<List<Chart>> GetCharts();
        void Add(Chart chart);
        Task<Chart> GetChart(int id);
    }
}
