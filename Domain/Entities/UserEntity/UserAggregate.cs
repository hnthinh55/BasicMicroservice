using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserEntity
{
    public partial class User
    {
        public User ( string userName, string email, string password) : base()
        {
            UserName = userName;
            Email = email;
            Password = password;
            VerifyPasswordCode = Guid.NewGuid();
        }

        public bool ValidOnAdd()
        {
            return
                !string.IsNullOrEmpty(UserName)
                && !string.IsNullOrEmpty(Email);
        }
    }
}
