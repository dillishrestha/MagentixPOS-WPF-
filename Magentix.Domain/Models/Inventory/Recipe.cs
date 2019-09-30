using System.Collections.Generic;
using System.Linq;
using Magentix.Domain.Models.Menus;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Inventory
{
    public class Recipe : EntityClass
    {
        public virtual MenuItemPortion Portion { get; set; }
        public decimal FixedCost { get; set; }

        private IList<RecipeItem> _recipeItems;
        public virtual IList<RecipeItem> RecipeItems
        {
            get { return _recipeItems; }
            set { _recipeItems = value; }
        }

        public Recipe()
        {
            _recipeItems = new List<RecipeItem>();
        }

        public IList<RecipeItem> GetValidRecipeItems()
        {
            var result= 
                RecipeItems.Where(x => x.InventoryItem != null && x.Quantity > 0);
            return result.ToList();
        }
    }
}
