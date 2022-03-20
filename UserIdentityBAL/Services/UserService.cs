using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityDAL.Data;
using UserIdentityDAL.Models;
using UserIdentityDAL.Repositories;

namespace UserIdentityBAL.Services
{
    public class UserService : Repository<User>, IUserService
    {

        public UserService(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<int> AddUser(User user)
        {
            try
            {
                var result = await Add(user);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetList()
        {
            var userlist = await GetAll();

            return userlist.ToList();
        }
        public async Task<List<User>> GetUserList()
        {

            var userlist = await GetAll();


            return userlist.ToList();
        }

        public async Task<int> DeleteUser(int Id)
        {
            try
            {
                var useritem = await GetById(Id);

                var result = await Remove(useritem);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<User> GetUser(int Id)
        {
            var useritem = await GetById(Id);

            return useritem;
        }

        public async Task<int> UpdateUser(User user)
        {
            try
            {
                var result = await UpdateAsync(user);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
