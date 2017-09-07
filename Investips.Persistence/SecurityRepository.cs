using System.Collections.Generic;
using System.Threading.Tasks;
using Investips.Core;
using Investips.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Investips.Persistence
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly InvestipsDbContext context;

        public SecurityRepository(InvestipsDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Security>> GetSecurities()
        {
            return await context.Securities
                .ToListAsync();
        }

        public void Add(Security security)
        {
            context.Securities.Add(security);
        }

        public async Task<Security> GetSecurity(int id)
        {
            return await context.Securities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Security> GetSecurityWithStudies(int id)
        {
            return await context.Securities
                .Include(s => s.WidgetShapes).ThenInclude(w => w.WidgetShapePoints)
                .SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
