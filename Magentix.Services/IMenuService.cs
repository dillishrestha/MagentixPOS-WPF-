using System.Collections.Generic;
using Magentix.Domain.Models.Menus;
using Magentix.Persistance.Common;

namespace Magentix.Services
{
    public interface IMenuService
    {
        IEnumerable<MenuItem> GetMenuItemsByGroupCode(string menuItemGroupCode);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<MenuItem> GetMenuItemsWithPortions();
        IEnumerable<MenuItemData> GetMenuItemData();
        IEnumerable<ScreenMenu> GetScreenMenus();
        IEnumerable<string> GetMenuItemNames();
        IEnumerable<string> GetMenuItemGroupCodes();
        IEnumerable<string> GetMenuItemTags();
        MenuItem GetMenuItemById(int id);
    }
}
