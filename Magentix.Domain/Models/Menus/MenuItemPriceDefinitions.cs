using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Tickets;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Menus
{
    public class MenuItemPriceDefinition : EntityClass
    {
        [StringLength(10)]
        public string PriceTag { get; set; }
    }
}
