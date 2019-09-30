using System.ComponentModel.Composition;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.ModifierModule
{
    [Export]
    public class TicketNoteEditorViewModel : ObservableObject
    {
        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                RaisePropertyChanged(() => SelectedTicket);
            }
        }

        public ICaptionCommand CloseCommand { get; set; }

        public TicketNoteEditorViewModel()
        {
            CloseCommand = new CaptionCommand<string>(Resources.Close, OnClose);
        }

        private void OnClose(string obj)
        {
            SelectedTicket = null;
            EventServiceFactory.EventService.PublishEvent(EventTopicNames.ActivatePosView);
        }
    }
}
