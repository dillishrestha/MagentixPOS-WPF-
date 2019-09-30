using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Menus;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Tickets
{
    public class OrderTagMap : AbstractMap
    {
        public int OrderTagGroupId { get; set; }
        public string MenuItemGroupCode { get; set; }
        public int MenuItemId { get; set; }
    }
}
