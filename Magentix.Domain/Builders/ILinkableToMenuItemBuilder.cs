using Magentix.Domain.Models.Menus;

namespace Magentix.Domain.Builders
{
    public interface ILinkableToMenuItemBuilder<T> where T : ILinkableToMenuItemBuilder<T>
    {
        void Link(MenuItem menuItem);
        MenuItemBuilderFor<T> CreateMenuItem(string menuItemName);
    }
}