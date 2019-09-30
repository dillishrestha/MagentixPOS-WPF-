using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.AccountModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class CreateBatchAccountTransactionDocument : ActionType
    {
        private readonly IAccountService _accountService;

        [ImportingConstructor]
        public CreateBatchAccountTransactionDocument(IAccountService accountService)
        {
            _accountService = accountService;
        }

        protected override object GetDefaultData()
        {
            return new { AccountTransactionDocumentName = "" };
        }

        protected override string GetActionName()
        {
            return Resources.BatchCreateDocuments;
        }

        protected override string GetActionKey()
        {
            return ActionNames.CreateBatchAccountTransactionDocument;
        }

        public override void Process(ActionData actionData)
        {
            var documentName = actionData.GetAsString("AccountTransactionDocumentName");
            _accountService.CreateBatchAccountTransactionDocument(documentName);
        }
    }
}
