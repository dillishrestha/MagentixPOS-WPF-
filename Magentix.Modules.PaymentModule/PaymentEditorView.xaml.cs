using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Magentix.Modules.PaymentModule
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    
    [Export]
    public partial class PaymentEditorView : UserControl
    {
        [ImportingConstructor]
        public PaymentEditorView(PaymentEditorViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
