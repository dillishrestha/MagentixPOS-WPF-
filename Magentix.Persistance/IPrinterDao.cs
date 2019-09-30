using System.Collections.Generic;
using Magentix.Domain.Models.Settings;

namespace Magentix.Persistance
{
    public interface IPrinterDao
    {
        IEnumerable<Printer> GetPrinters();
        IEnumerable<PrinterTemplate> GetPrinterTemplates();
    }
}
