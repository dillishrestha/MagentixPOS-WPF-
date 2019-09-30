using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Magentix.Domain.Models.Inventory;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Common.Services;
using Magentix.Presentation.Services;

namespace Magentix.Modules.InventoryModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class RecipeListViewModel : EntityCollectionViewModelBase<RecipeViewModel, Recipe>
    {
        private readonly IInventoryService _inventoryService;
        public ICaptionCommand TestRecipesCommand { get; set; }
        public ICaptionCommand TestAllRecipesCommand { get; set; }

        [ImportingConstructor]
        public RecipeListViewModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            TestRecipesCommand = new CaptionCommand<string>(string.Format(Resources.Find_f, Resources.RequiredRecipes), OnTestRequiredRecipes);
            TestAllRecipesCommand = new CaptionCommand<string>(string.Format(Resources.Find_f, Resources.MissingRecipes), OnTestMissingRecipes);
            CustomCommands.Add(TestRecipesCommand);
            CustomCommands.Add(TestAllRecipesCommand);
        }

        private void OnTestRequiredRecipes(string obj)
        {
            Mouse.SetCursor(Cursors.Wait);
            var items = _inventoryService.GetRequiredRecipesForSales().ToList();
            Mouse.UpdateCursor();
            if (items.Any())
            {
                var message = string.Join("\r\n", items);
                InteractionService.UserIntraction.GetStringFromUser(Resources.RequiredRecipes, items.Count + " " + Resources.RequiredRecipes, message);
            }
            else
            {
                MessageBox.Show(string.Format(Resources.No_f, Resources.RequiredRecipes));
            }
        }
        private void OnTestMissingRecipes(string obj)
        {
            Mouse.SetCursor(Cursors.Wait);
            var items = _inventoryService.GetMissingRecipes().ToList();
            Mouse.UpdateCursor();
            if (items.Any())
            {
                var message = string.Join("\r\n", items);
                InteractionService.UserIntraction.GetStringFromUser(Resources.MissingRecipes, items.Count + " " + Resources.MissingRecipes, message);
            }
            else
            {
                MessageBox.Show(string.Format(Resources.No_f, Resources.MissingRecipes));
            }
        }
    }
}
