using System.ComponentModel.Composition;
using Magentix.Domain.Models.Settings;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.ModelBase;

namespace Magentix.Modules.SettingsModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class TerminalListViewModel : EntityCollectionViewModelBase<TerminalViewModel, Terminal>
    {
        protected override string CanDeleteItem(Terminal model)
        {
            var count = Workspace.Count<Terminal>();
            if (count == 1) return Resources.DeleteErrorShouldHaveAtLeastOneTerminal;
            return base.CanDeleteItem(model);
        }
    }
}
