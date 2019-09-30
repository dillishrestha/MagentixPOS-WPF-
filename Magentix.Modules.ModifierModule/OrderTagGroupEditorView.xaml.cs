using System.ComponentModel.Composition;
using System.Windows.Controls;
using Magentix.Presentation.Common;
using Magentix.Presentation.Services.Common;
using Magentix.Presentation.ViewModels;

namespace Magentix.Modules.ModifierModule
{
    /// <summary>
    /// Interaction logic for SelectedOrdersView.xaml
    /// </summary>
    /// 
    [Export]
    public partial class OrderTagGroupEditorView : UserControl
    {
        [ImportingConstructor]
        public OrderTagGroupEditorView(OrderTagGroupEditorViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void TextBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var t = sender as TextBox;
            if (t != null) t.BackgroundFocus();
        }
    }
}
