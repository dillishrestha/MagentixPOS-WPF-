using System.Collections.Generic;
using System.ComponentModel.Composition;
using Magentix.Domain.Models.Accounts;
using Magentix.Domain.Models.Settings;
using Magentix.Infrastructure.Data;
using Magentix.Infrastructure.Data.Validation;
using Magentix.Localization.Properties;
using Magentix.Persistance.Data;

namespace Magentix.Persistance.Implementations
{
    [Export(typeof(IPrinterDao))]
    class PrinterDao : IPrinterDao
    {
        [ImportingConstructor]
        public PrinterDao()
        {
            ValidatorRegistry.RegisterDeleteValidator(new PrinterDeleteValidator());
            ValidatorRegistry.RegisterDeleteValidator(new PrinterTemplateDeleteValidator());
        }

        public IEnumerable<Printer> GetPrinters()
        {
            return Dao.Query<Printer>();
        }

        public IEnumerable<PrinterTemplate> GetPrinterTemplates()
        {
            return Dao.Query<PrinterTemplate>();
        }
    }

    public class PrinterDeleteValidator : SpecificationValidator<Printer>
    {
        public override string GetErrorMessage(Printer model)
        {
            if (Dao.Exists<Terminal>(x => x.ReportPrinterId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.Printer, Resources.Terminal);
            if (Dao.Exists<Terminal>(x => x.TransactionPrinterId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.Printer, Resources.Terminal);
            if (Dao.Exists<PrinterMap>(x => x.PrinterId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.Printer, Resources.PrintJob);
            return "";
        }
    }

    public class PrinterTemplateDeleteValidator : SpecificationValidator<PrinterTemplate>
    {
        public override string GetErrorMessage(PrinterTemplate model)
        {
            if (Dao.Exists<PrinterMap>(y => y.PrinterTemplateId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.PrinterTemplate, Resources.PrintJob);
            if (Dao.Exists<AccountTransactionDocumentType>(y => y.PrinterTemplateId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.PrinterTemplate, Resources.AccountTransactionDocument);
            return "";
        }
    }
}
