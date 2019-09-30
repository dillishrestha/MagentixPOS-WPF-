using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Accounts;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Inventory
{
    public class InventoryTransactionDocumentType : EntityClass, IOrderable
    {
        public virtual AccountTransactionType AccountTransactionType { get; set; }
        public virtual InventoryTransactionType InventoryTransactionType { get; set; }
        public int SourceEntityTypeId { get; set; }
        public int TargetEntityTypeId { get; set; }
        public int DefaultSourceEntityId { get; set; }
        public int DefaultTargetEntityId { get; set; }
        public int SortOrder { get; set; }
        public string UserString { get { return Name; } }
    }
}
