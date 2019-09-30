using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Magentix.Domain.Models.Settings;
using Magentix.Localization.Properties;
using Magentix.Modules.SettingsModule.BrowserViews;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.SettingsModule
{
    [ModuleExport(typeof(SettingsModule))]
    public class SettingsModule : ModuleBase
    {
        [ImportingConstructor]
        public SettingsModule()
        {
            AddDashboardCommand<SettingsViewModel>(Resources.LocalSettings, Resources.Settings, 20);
            AddDashboardCommand<TerminalListViewModel>(Resources.Terminals, Resources.Settings, 21);
            AddDashboardCommand<EntityCollectionViewModelBase<NumeratorViewModel, Numerator>>(Resources.Numerators, Resources.Settings, 21);
            AddDashboardCommand<EntityCollectionViewModelBase<ForeignCurrencyViewModel, ForeignCurrency>>(string.Format(Resources.List_f, Resources.Currency), Resources.Settings, 21);
            AddDashboardCommand<EntityCollectionViewModelBase<StateViewModel, State>>(Resources.State.ToPlural(), Resources.Settings, 21);
            AddDashboardCommand<ProgramSettingsViewModel>(Resources.ProgramSettings, Resources.Settings, 22);
            //AddDashboardCommand<MagentixPosWebsite>(Resources.MagentixPosWebsite, Resources.MagentixNetwork, 90);
            //AddDashboardCommand<MagentixPosDocumentation>(string.Format("MagentixPOS {0}", Resources.Documentation), Resources.MagentixNetwork, 91);
            //AddDashboardCommand<MagentixPosForum>(string.Format("MagentixPOS {0}", Resources.Forum), Resources.MagentixNetwork, 92);
            //AddDashboardCommand<MagentixPosDevelopment>(string.Format("MagentixPOS {0}", Resources.Development), Resources.MagentixNetwork, 93);
            //AddDashboardCommand<MagentixPosWiki>(string.Format("MagentixPOS {0}", Resources.Wiki), Resources.MagentixNetwork, 94);
        }
    }
}
