using System;
using System.ComponentModel.Composition;
using System.Linq;
using Magentix.Domain.Models.Accounts;
using Magentix.Domain.Models.Settings;
using Magentix.Services.Implementations.PrinterModule.ValueChangers;

namespace Magentix.Services.Implementations.PrinterModule.ObjectFormatters
{
    [Export(typeof(IDocumentFormatter))]
    public class AccountTransactionDocumentFormatter : IDocumentFormatter
    {
        private readonly IExpressionService _expressionService;
        private readonly ISettingService _settingService;
        private readonly AccountTransactionDocumentValueChanger _valueChanger;

        [ImportingConstructor]
        public AccountTransactionDocumentFormatter(IExpressionService expressionService, ISettingService settingService,
            AccountTransactionDocumentValueChanger valueChanger)
        {
            _expressionService = expressionService;
            _settingService = settingService;
            _valueChanger = valueChanger;
        }

        public string[] GetFormattedDocument(AccountTransactionDocument document, PrinterTemplate printerTemplate)
        {
            var content = _valueChanger.GetValue(printerTemplate, document);
            content = UpdateExpressions(content);
            return content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        private string UpdateExpressions(string data)
        {
            data = _expressionService.ReplaceExpressionValues(data);
            data = _settingService.ReplaceSettingValues(data);
            return data;
        }


        public Type ObjectType
        {
            get { return typeof(AccountTransactionDocument); }
        }

        public string[] GetFormattedDocument(object item, PrinterTemplate printerTemplate)
        {
            return GetFormattedDocument(item as AccountTransactionDocument, printerTemplate);
        }
    }
}