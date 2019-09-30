using System.ComponentModel;
using Magentix.Domain.Models.Entities;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Widgets;
using Magentix.Presentation.Services;
using Magentix.Services;

namespace Magentix.Modules.TicketModule.Widgets.TicketExplorer
{
    class TicketExplorerWidgetViewModel : WidgetViewModel
    {
        public TicketExplorerWidgetViewModel(Widget model, IApplicationState applicationState,
             ITicketServiceBase ticketServiceBase, IUserService userService, ICacheService cacheService)
            : base(model, applicationState)
        {
            TicketExplorerViewModel = new TicketExplorerViewModel(ticketServiceBase, userService, cacheService, applicationState);
        }

        [Browsable(false)]
        public TicketExplorerViewModel TicketExplorerViewModel { get; private set; }

        protected override object CreateSettingsObject()
        {
            return null;
        }

        public override void Refresh()
        {
            TicketExplorerViewModel.Refresh();
        }
    }
}
