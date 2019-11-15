using Starter.Data.ViewModels;

namespace Starter.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        //protected MainViewModel ViewModel;

        public MainWindow(ICatsViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}