using MVVMDemoApp.ViewModel;
using System.Windows;

namespace MVVMDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Bootstrapper.RunApplication();
        }
    }
}
