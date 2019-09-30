using Microsoft.Practices.Prism.Commands;
using Magentix.Domain.Models.Accounts;
using Magentix.Presentation.Common;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.AccountModule
{
    public class DocumentTypeButtonViewModel : ObservableObject
    {
        public DocumentTypeButtonViewModel(AccountTransactionDocumentType model, Account account)
        {
            Model = model;
            Account = account;
            SelectDocumentTypeCommand = new DelegateCommand<string>(OnSelectDocumentType);
        }

        public AccountTransactionDocumentType Model { get; set; }
        public Account Account { get; set; }
        public DelegateCommand<string> SelectDocumentTypeCommand { get; set; }

        public string ButtonHeader { get { return Model.ButtonHeader.Replace(" ", "\r"); } }
        public string ButtonColor { get { return Model.ButtonColor; } }

        private void OnSelectDocumentType(string obj)
        {
            if (Account != null)
            {
                var creationData = new DocumentCreationData(Account, Model);
                creationData.PublishEvent(EventTopicNames.AccountTransactionDocumentSelected);
            }
            else
            {
                Model.PublishEvent(EventTopicNames.BatchCreateDocument);
            }
        }
    }
}
