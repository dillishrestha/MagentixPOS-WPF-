using System.ComponentModel.Composition;
using Magentix.Domain.Models.Settings;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Services;

namespace Magentix.Modules.AutomationModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class TriggerListViewModel : EntityCollectionViewModelBase<TriggerViewModel, Trigger>
    {
        private readonly ITriggerService _triggerService;
        private readonly IMethodQueue _methodQueue;

        [ImportingConstructor]
        public TriggerListViewModel(ITriggerService triggerService, IMethodQueue methodQueue)
        {
            _triggerService = triggerService;
            _methodQueue = methodQueue;
        }

        protected override void OnDeleteItem(object obj)
        {
            base.OnDeleteItem(obj);
            _methodQueue.Queue("UpdateCronObjects", _triggerService.UpdateCronObjects);
        }
    }
}
