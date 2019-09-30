using System.Collections.Generic;
using Magentix.Domain.Models.Automation;

namespace Magentix.Persistance
{
    public interface IAutomationDao
    {
        Dictionary<string, string> GetScripts();
        AppAction GetActionById(int appActionId);
        IEnumerable<string> GetAutomationCommandNames();
    }
}
