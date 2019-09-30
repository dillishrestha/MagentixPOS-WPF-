using System.ComponentModel.Composition;
using System.Linq;
using Magentix.Domain.Models.Inventory;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Services;

namespace Magentix.Modules.InventoryModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class TransactionDocumentListViewModel : EntityCollectionViewModelBase<TransactionDocumentViewModel, InventoryTransactionDocument>
    {
        private readonly IApplicationState _applicationState;

        [ImportingConstructor]
        public TransactionDocumentListViewModel(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        protected override bool CanAddItem(object obj)
        {
            return _applicationState.CurrentWorkPeriod != null;
        }
    }
}
