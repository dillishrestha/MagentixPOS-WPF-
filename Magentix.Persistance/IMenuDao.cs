using System.Collections.Generic;
using Magentix.Domain.Models.Menus;
using Magentix.Persistance.Common;

namespace Magentix.Persistance
{
    public interface IMenuDao
    {
        IEnumerable<ScreenMenu> GetScreenMenus();
        IEnumerable<string> GetMenuItemNames();
        IEnumerable<string> GetMenuItemGroupCodes();
        IEnumerable<string> GetMenuItemTags();
        IEnumerable<MenuItem> GetMenuItemsByGroupCode(string menuItemGroupCode);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<MenuItemData> GetMenuItemData();
        MenuItem GetMenuItemById(int id);
        IEnumerable<MenuItem> GetMenuItemsWithPortions();
    }
}
