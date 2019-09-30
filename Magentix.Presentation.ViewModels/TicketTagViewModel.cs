using Magentix.Domain.Models.Tickets;
using Magentix.Presentation.Common;

namespace Magentix.Presentation.ViewModels
{
    public class TicketTagViewModel : ObservableObject
    {
        public TicketTagViewModel(TicketTag model)
        {
            Model = model;
        }

        public TicketTag Model { get; set; }

        public string Name
        {
            get { return Model.Name; }
            set { Model.Name = value; }
        }

        public string Display { get { return Model.Display; } }

        public void Refresh()
        {
            RaisePropertyChanged(() => Name);
        }
    }
}
