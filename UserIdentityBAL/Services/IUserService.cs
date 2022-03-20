using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityDAL.Models;
using UserIdentityDAL.Repositories;

namespace UserIdentityBAL.Services
{
    public interface IUserService : IRepository<User>
    {
        Task<List<User>> GetList();
        Task<User> GetUser(int Id);
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int Id);
    }
}
