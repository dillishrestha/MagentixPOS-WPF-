using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Menus
{
    public class TaxTemplateMap : AbstractMap
    {
        public int TaxTemplateId { get; set; }
        public string MenuItemGroupCode { get; set; }
        public int MenuItemId { get; set; }
    }
}
