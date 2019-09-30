using Magentix.Domain.Models.Settings;

namespace Magentix.Services.Common
{
    public interface IWorkPeriodProcessor
    {
        void ProcessWorkPeriodStart(WorkPeriod workPeriod);
        void ProcessWorkPeriodEnd(WorkPeriod workPeriod);
    }
}