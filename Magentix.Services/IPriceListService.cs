using System.Collections.Generic;
using Magentix.Domain.Models.Menus;
using Magentix.Persistance;
using Magentix.Persistance.Common;

namespace Magentix.Services
{
    public interface IPriceListService
    {
        void DeleteMenuItemPricesByPriceTag(string priceTag);
        void UpdatePriceTags(MenuItemPriceDefinition model);
        IEnumerable<string> GetTags();
        IEnumerable<PriceData> CreatePrices();
        void UpdatePrices(IList<PriceData> prices);
    }
}
