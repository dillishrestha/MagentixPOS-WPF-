using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;
using Magentix.Domain.Models.Settings;
using Magentix.Domain.Models.Tickets;
using Magentix.Infrastructure.Settings;
using Magentix.Localization.Properties;
using Magentix.Services.Common;
using Magentix.Services.Implementations.PrinterModule.Formatters;
using Magentix.Services.Implementations.PrinterModule.PrintJobs;
using Magentix.Services.Implementations.PrinterModule.Tools;
using Magentix.Services.Implementations.PrinterModule.ValueChangers;

namespace Magentix.Services.Implementations.PrinterModule
{
    [Export(typeof(IPrinterService))]
    public class PrinterService : IPrinterService
    {
        private readonly ICacheService _cacheService;
        private readonly ILogService _logService;
        private readonly TicketFormatter _ticketFormatter;
        private readonly FunctionRegistry _functionRegistry;
        private readonly TicketPrintTaskBuilder _ticketPrintTaskBuilder;

        [ImportingConstructor]
        PrinterService(ISettingService settingService, ICacheService cacheService, IExpressionService expressionService, ILogService logService,
            TicketFormatter ticketFormatter, FunctionRegistry functionRegistry, TicketPrintTaskBuilder ticketPrintTaskBuilder)
        {
            _cacheService = cacheService;
            _logService = logService;
            _ticketFormatter = ticketFormatter;
            _functionRegistry = functionRegistry;
            _ticketPrintTaskBuilder = ticketPrintTaskBuilder;
            _functionRegistry.RegisterFunctions();
        }

        [ImportMany]
        public IEnumerable<IDocumentFormatter> DocumentFormatters { get; set; }

        [ImportMany]
        public IEnumerable<ICustomPrinter> CustomPrinters { get; set; }

        public IEnumerable<string> GetPrinterNames()
        {
            return PrinterInfo.GetPrinterNames();
        }

        public IEnumerable<string> GetCustomPrinterNames()
        {
            return CustomPrinters.Select(x => x.Name);
        }

        public ICustomPrinter GetCustomPrinter(string customPrinterName)
        {
            return CustomPrinters.FirstOrDefault(x => x.Name == customPrinterName);
        }

        public void PrintTicket(Ticket ticket, PrintJob printJob, Func<Order, bool> orderSelector, bool highPriority)
        {
            TicketPrinter.For(ticket)
                .WithPrinterService(this)
                .WithLogService(_logService)
                .WithTaskBuilder(_ticketPrintTaskBuilder)
                .WithPrintJob(printJob)
                .WithOrderSelector(orderSelector)
                .IsHighPriority(highPriority)
                .Print();
        }

        public void PrintObject(object item, Printer printer, PrinterTemplate printerTemplate)
        {
            var formatter = DocumentFormatters.FirstOrDefault(x => x.ObjectType == item.GetType());
            if (formatter != null)
            {
                var lines = formatter.GetFormattedDocument(item, printerTemplate);
                if (lines != null)
                {
                    AsyncPrintTask.Exec(false, () => PrintJobFactory.CreatePrintJob(printer, this).DoPrint(lines), _logService);
                }
            }
        }

        public void PrintReport(FlowDocument document, Printer printer)
        {
            ReportPrinter.For(document)
                .WithPrinterService(this)
                .WithLogService(_logService)
                .WithPrinter(printer)
                .Print();
        }

        public void ExecutePrintJob(PrintJob printJob, bool highPriority)
        {
            PrintJobExecutor.For(printJob)
                .WithPrinterService(this)
                .WithLogSerivce(_logService)
                .WithCacheService(_cacheService)
                .IsHighPriority(highPriority)
                .Execute();
        }

        public IDictionary<string, string> GetTagDescriptions()
        {
            return _functionRegistry.Descriptions;
        }

        public void ResetCache()
        {
            PrinterInfo.ResetCache();
        }

        public string GetPrintingContent(Ticket ticket, string format, int width)
        {
            var lines = _ticketFormatter.GetFormattedTicket(ticket, ticket.Orders, new PrinterTemplate { Template = format });
            var result = new FormattedDocument(lines, width).GetFormattedText();
            return result;
        }

        public string ExecuteFunctions<T>(string printerTemplate, T model)
        {
            return _functionRegistry.ExecuteFunctions(printerTemplate, model, new PrinterTemplate { Template = printerTemplate });
        }

        public object GetCustomPrinterData(string customPrinterName, string customPrinterData)
        {
            var printer = GetCustomPrinter(customPrinterName);
            return printer != null ? printer.GetSettingsObject(customPrinterData) : "";
        }
    }
}
