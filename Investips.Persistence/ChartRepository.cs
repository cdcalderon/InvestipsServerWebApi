using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investips.Core;
using Investips.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Investips.Persistence
{
    public class ChartRepository : IChartRepository
    {
        private readonly InvestipsDbContext _context;

        public ChartRepository(InvestipsDbContext context)
        {
            _context = context;
        }
        
        public Task<List<Chart>> GetCharts() {
            return _context.Charts.ToListAsync();
        }
        public void Add(Chart chart)
        {
            _context.Charts.Add(chart);
        }

        public async Task<Chart> GetChart(int id)
        {
            return await _context.Charts.FindAsync(id);
        } 
    }
}
