using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Magentix.Modules.EntityModule
{
    /// <summary>
    /// Interaction logic for ResourceSwitcherView.xaml
    /// </summary>

    [Export]
    public partial class EntitySwitcherView : UserControl
    {
        [ImportingConstructor]
        public EntitySwitcherView(EntitySwitcherViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
