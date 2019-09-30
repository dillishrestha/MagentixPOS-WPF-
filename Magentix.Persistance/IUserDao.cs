using System.Collections.Generic;
using Magentix.Domain.Models.Users;

namespace Magentix.Persistance
{
    public interface IUserDao
    {
        bool GetIsUserExists(string pinCode);
        User GetUserByPinCode(string pinCode);
        IEnumerable<UserRole> GetUserRoles();
    }
}
