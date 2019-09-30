﻿using System.Windows.Documents;
using System.Windows.Media;
using Magentix.Domain.Models.Settings;
using Magentix.Services.Implementations.PrinterModule.Formatters;
using Magentix.Services.Implementations.PrinterModule.Tools;

namespace Magentix.Services.Implementations.PrinterModule.PrintJobs
{
    public class TextPrinterJob : AbstractPrintJob
    {
        public TextPrinterJob(Printer printer)
            : base(printer)
        {
        }

        public override void DoPrint(string[] lines)
        {
            var q = PrinterInfo.GetPrinter(Printer.ShareName);
            var text = new FormattedDocument(lines, Printer.CharsPerLine).GetFormattedText();
            var run = new Run(text) {Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))};
            PrintFlowDocument(q, new FlowDocument(new Paragraph(run)));
        }

        public override void DoPrint(FlowDocument document)
        {
            var q = PrinterInfo.GetPrinter(Printer.ShareName);
            PrintFlowDocument(q, document);
        }
    }
}
