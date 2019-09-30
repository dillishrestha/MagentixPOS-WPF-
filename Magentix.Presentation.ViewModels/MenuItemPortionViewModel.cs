using Magentix.Domain.Models.Menus;
using Magentix.Presentation.Common;

namespace Magentix.Presentation.ViewModels
{
    public class MenuItemPortionViewModel : ObservableObject
    {
        public MenuItemPortion Model { get; set; }

        public MenuItemPortionViewModel(MenuItemPortion model)
        {
            Model = model;
        }

        public string Name
        {
            get { return Model.Name; }
            set { Model.Name = value; }
        }

        public decimal Price
        {
            get { return Model.Price; }
            set { Model.Price = value; }
        }

        public void Refresh()
        {
            RaisePropertyChanged(() => Name);
        }
    }
}
