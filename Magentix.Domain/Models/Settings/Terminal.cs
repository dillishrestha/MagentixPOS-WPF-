using System.Collections.Generic;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Settings
{
    public class Terminal : EntityClass
    {
        public bool IsDefault { get; set; }
        public bool AutoLogout { get; set; }

        public int ReportPrinterId { get; set; }
        public int TransactionPrinterId { get; set; }

        private static Terminal _defaultTerminal;
        public static Terminal DefaultTerminal { get { return _defaultTerminal ?? (_defaultTerminal = new Terminal { Name = "Default Terminal" }); } }

    }
}
