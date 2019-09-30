using System.Collections.Generic;
using Magentix.Domain.Models.Entities;
using Magentix.Domain.Models.Tickets;
using Magentix.Domain.Models.Users;
using Magentix.Presentation.Services.Common;

namespace Magentix.Presentation.Services
{
    public interface IApplicationStateSetter
    {
        void SetCurrentLoggedInUser(User user);
        void SetCurrentDepartment(int departmentId);
        void SetCurrentApplicationScreen(AppScreens appScreen);
        EntityScreen SetSelectedEntityScreen(EntityScreen entityScreen);
        void SetApplicationLocked(bool isLocked);
        void SetNumberpadValue(string value);
        void SetCurrentTicketType(TicketType ticketType);
        void SetCurrentTerminal(string terminalName);
        void ResetWorkPeriods();
    }
}