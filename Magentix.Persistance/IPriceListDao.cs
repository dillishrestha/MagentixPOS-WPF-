using System.Collections.Generic;
using Magentix.Persistance.Common;

namespace Magentix.Persistance
{
    public interface IPriceListDao
    {
        void DeleteMenuItemPricesByPriceTag(string priceTag);
        void UpdatePriceTags(int id, string priceTag);
        IEnumerable<string> GetTags();
        IEnumerable<PriceData> CreatePrices();
        void UpdatePrices(IList<PriceData> prices);
    }
}
