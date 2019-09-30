using System;
using System.Collections.Generic;
using Magentix.Domain.Models.Settings;

namespace Magentix.Presentation.Services
{
    public interface IWorkPeriodService 
    {
        bool StartWorkPeriod(string description);
        bool StopWorkPeriod(string description);
        IEnumerable<WorkPeriod> GetLastWorkPeriods(int count);
        DateTime GetWorkPeriodStartDate();
    }
}
