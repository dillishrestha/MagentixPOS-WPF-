using Magentix.Domain.Models.Accounts;

namespace Magentix.Modules.AccountModule
{
    class DocumentCreationData
    {
        public DocumentCreationData(Account account,AccountTransactionDocumentType documentType)
        {
            Account = account;
            DocumentType = documentType;
        }

        public Account Account { get; set; }
        public AccountTransactionDocumentType DocumentType { get; set; }
    }
}
