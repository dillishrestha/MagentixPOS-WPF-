using Magentix.Domain.Models.Menus;
using Magentix.Domain.Models.Tickets;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Settings
{
    public class PrinterMap : ValueClass
    {
        public int PrintJobId { get; set; }
        public string MenuItemGroupCode { get; set; }
        public int MenuItemId { get; set; }
        public int PrinterId { get; set; }
        public int PrinterTemplateId { get; set; }
    }
}
