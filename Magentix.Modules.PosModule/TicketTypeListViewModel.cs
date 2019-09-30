using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.Practices.Prism.Commands;
using Magentix.Domain.Models.Entities;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Services.Common;
using Magentix.Services;

namespace Magentix.Modules.PosModule
{
    [Export]
    public class TicketTypeListViewModel : ObservableObject
    {
        private readonly ICacheService _cacheService;
        public DelegateCommand<TicketType> SelectionCommand { get; set; }
        public CaptionCommand<string> CloseCommand { get; set; }

        [ImportingConstructor]
        public TicketTypeListViewModel(ICacheService cacheService)
        {
            _cacheService = cacheService;
            SelectionCommand = new DelegateCommand<TicketType>(OnSelectTicketType);
            CloseCommand = new CaptionCommand<string>(Resources.Close, OnClose);
            TicketTypeList = new ObservableCollection<TicketType>();
        }

        private void OnClose(string obj)
        {
            CommonEventPublisher.PublishEntityOperation<Entity>(null, EventTopicNames.SelectEntity, EventTopicNames.EntitySelected);
        }

        private void OnSelectTicketType(TicketType obj)
        {
            obj.PublishEvent(EventTopicNames.TicketTypeSelected, true);
        }

        public ObservableCollection<TicketType> TicketTypeList { get; set; }

        public void Update()
        {
            TicketTypeList.Clear();
            TicketTypeList.AddRange(_cacheService.GetTicketTypes());
            RaisePropertyChanged(() => RowCount);
            RaisePropertyChanged(() => ColumnCount);
        }

        public int ColumnCount { get { return TicketTypeList.Count % 7 == 0 ? TicketTypeList.Count / 7 : (TicketTypeList.Count / 7) + 1; } }
        public int RowCount { get { return 7; } }
    }
}
