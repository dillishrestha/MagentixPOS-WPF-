using Magentix.Domain.Models.Settings;

namespace Magentix.Services.Implementations.PrinterModule
{
    public class TicketPrintTask
    {
        public Printer Printer { get; set; }
        public string[] Lines { get; set; }
    }
}