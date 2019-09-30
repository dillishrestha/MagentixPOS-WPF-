using System.Windows;

namespace Magentix.Presentation.Controls.Interaction
{
    /// <summary>
    /// Interaction logic for FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        public FeedbackWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
