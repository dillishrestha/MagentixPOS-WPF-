using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Magentix.Modules.EntityModule
{
    /// <summary>
    /// Interaction logic for LocationSelectorView.xaml
    /// </summary>

    [Export]
    public partial class EntitySelectorView : UserControl
    {
        [ImportingConstructor]
        public EntitySelectorView(EntitySelectorViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
