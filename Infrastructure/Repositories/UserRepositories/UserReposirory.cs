using Domain.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepositories
{
    public class UserReposirory : Repository<User>, IUserRepository
    {
        public UserReposirory(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<IEnumerable<User>> AllUsers()
        {
            return await GetAllAsync();
        }

        public User NewUser(string username, string email, string password)
        {
            var user = new User(username, email, password);
            if (user.ValidOnAdd())
            {
                Add(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }
    }
}
