﻿using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Magentix.Domain.Models.Menus;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.MenuModule
{
    [ModuleExport(typeof(MenuModule))]
    public class MenuModule : ModuleBase
    {
        [ImportingConstructor]
        public MenuModule()
        {
            AddDashboardCommand<EntityCollectionViewModelBase<MenuItemViewModel, MenuItem>>(Resources.ProductList, Resources.Products, 33);
            AddDashboardCommand<EntityCollectionViewModelBase<ScreenMenuViewModel, ScreenMenu>>(Resources.MenuList, Resources.Products, 33);
            AddDashboardCommand<PriceListViewModel>(Resources.BatchPriceList, Resources.Products, 33);
            AddDashboardCommand<MenuItemPriceDefinitionListViewModel>(Resources.PriceDefinitions, Resources.Products, 33);
            AddDashboardCommand<EntityCollectionViewModelBase<TaxTemplateViewModel, TaxTemplate>>(Resources.TaxTemplate.ToPlural(), Resources.Products, 33);
            AddDashboardCommand<EntityCollectionViewModelBase<ProductTimerViewModel, ProductTimer>>(Resources.ProductTimer.ToPlural(), Resources.Products, 33);
        }
    }
}
