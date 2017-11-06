using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace Investips.Core
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<User> GetUser(int userId);
    }
}
