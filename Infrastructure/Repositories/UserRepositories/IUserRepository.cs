using Domain.Entities.UserEntity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User NewUser(string username,string email, string password);
        Task<IEnumerable<User>> AllUsers();
    }
}
