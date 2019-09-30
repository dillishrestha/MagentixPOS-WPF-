using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Inventories;
using Magentix.Domain.Models.Menus;
using Magentix.Domain.Models.Tickets;
using Magentix.Persistance.Data.Specification;

namespace Magentix.Services.Implementations.MenuModule
{
    public static class MenuSpecifications
    {


        public static Specification<ScreenMenuItem> ScreenMenuItemsByMenuItemId(int menuItemId)
        {
            return new DirectSpecification<ScreenMenuItem>(x => x.MenuItemId == menuItemId);
        }

        public static Specification<Recipe> RecipesByMenuItemId(int menuItemId)
        {
            return new DirectSpecification<Recipe>(x => x.Portion.MenuItemId == menuItemId);
        }

        public static Specification<OrderTag> OrderTagsByMenuItemId(int menuItemId)
        {
            return new DirectSpecification<OrderTag>(x=>x.MenuItemId == menuItemId);
        }
    }
}
