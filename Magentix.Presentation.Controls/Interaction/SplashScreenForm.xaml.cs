using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Magentix.Presentation.Controls.Interaction
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreenForm : Window
    {
        public SplashScreenForm()
        {
            InitializeComponent();

#if !DEBUG
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
#endif
        }
    }
}
