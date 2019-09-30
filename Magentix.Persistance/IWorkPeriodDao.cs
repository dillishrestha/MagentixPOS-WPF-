using System.Collections.Generic;
using Magentix.Domain.Models.Settings;
using Magentix.Infrastructure.Data;

namespace Magentix.Persistance
{
    public interface IWorkPeriodDao
    {
        void StartWorkPeriod(string description,IWorkspace workspace);
        void StopWorkPeriod(string description, IWorkspace workspace);
        IEnumerable<WorkPeriod> GetLastWorkPeriods(int count);
    }
}
