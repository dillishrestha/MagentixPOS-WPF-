using System.Collections.Generic;
using Magentix.Domain.Models.Tickets;
using Magentix.Domain.Models.Users;
using Magentix.Presentation.Services.Common;

namespace Magentix.Presentation.Services
{
    public interface IUserService : IPresentationService
    {
        string GetUserName(int userId);
        IEnumerable<Department> PermittedDepartments { get; }
        bool ContainsUser(int userId);
        bool IsDefaultUserConfigured { get; }
        User LoginUser(string pinValue);
        void LogoutUser(bool resetCache = true);
        bool IsUserPermittedFor(string permissionName);
        IEnumerable<UserRole> GetUserRoles();
    }
}
