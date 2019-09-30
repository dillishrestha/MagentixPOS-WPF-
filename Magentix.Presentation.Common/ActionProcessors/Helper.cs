using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;

namespace Magentix.Presentation.Common.ActionProcessors
{
    internal static class Helper
    {
        public static void ResetCache(ITriggerService triggerService, IApplicationState applicationState)
        {
            triggerService.UpdateCronObjects();
            EventServiceFactory.EventService.PublishEvent(EventTopicNames.ResetCache, true);
            applicationState.ResetState();
            applicationState.CurrentDepartment.PublishEvent(EventTopicNames.SelectedDepartmentChanged);
            applicationState.CurrentTicketType.PublishEvent(EventTopicNames.TicketTypeChanged);
        }
    }
}
