using System.Windows.Controls;

namespace Magentix.Modules.UserModule
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
            PasswordTextBox.GotFocus += PasswordTextBoxGotFocus;
        }

        void PasswordTextBoxGotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if(PasswordTextBox.Text.Contains("*"))
            PasswordTextBox.Clear();
        }
    }
}
