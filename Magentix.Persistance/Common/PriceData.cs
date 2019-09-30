using Magentix.Domain.Models.Menus;

namespace Magentix.Persistance.Common
{
    public class PriceData
    {
        public MenuItemPortion Portion { get; set; }
        public string Name { get; set; }

        public PriceData(MenuItemPortion portion, string name)
        {
            Portion = portion;
            Name = name;
        }
    }
}