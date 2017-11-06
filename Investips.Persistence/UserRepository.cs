using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investips.Core;
using Investips.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Investips.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly InvestipsDbContext _context;

        public UserRepository(InvestipsDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public async Task<User> GetUser(int userId)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        }
    }
}
