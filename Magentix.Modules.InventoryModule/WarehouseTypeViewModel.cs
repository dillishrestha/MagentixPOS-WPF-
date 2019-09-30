using System;
using System.ComponentModel.Composition;
using Magentix.Domain.Models.Inventory;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.ModelBase;

namespace Magentix.Modules.InventoryModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class WarehouseTypeViewModel : EntityViewModelBase<WarehouseType>
    {
        public override Type GetViewType()
        {
            return typeof(WarehouseTypeView);
        }

        public override string GetModelTypeString()
        {
            return Resources.WarehouseType;
        }
    }
}
