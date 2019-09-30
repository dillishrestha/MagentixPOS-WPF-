using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Accounts;

namespace Magentix.Presentation.Services
{
    public interface IReportServiceClient
    {
        void PrintAccountScreen(AccountScreen accountScreen);
        void PrintAccountTransactions(Account account,string filter);
    }
}
