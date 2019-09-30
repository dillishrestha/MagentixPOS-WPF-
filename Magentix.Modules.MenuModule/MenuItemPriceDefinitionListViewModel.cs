using System.ComponentModel.Composition;
using Magentix.Domain.Models.Menus;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Services;

namespace Magentix.Modules.MenuModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class MenuItemPriceDefinitionListViewModel : EntityCollectionViewModelBase<MenuItemPriceDefinitionViewModel, MenuItemPriceDefinition>
    {
        private readonly IPriceListService _priceListService;

        [ImportingConstructor]
        public MenuItemPriceDefinitionListViewModel(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }

        protected override void BeforeDeleteItem(MenuItemPriceDefinition item)
        {
            _priceListService.DeleteMenuItemPricesByPriceTag(item.PriceTag);
        }
    }
}
