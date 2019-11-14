using System.Windows;
using System.Windows.Input;

using Starter.Framework;
using Starter.Data.ViewModels;
using Starter.Data.Repositories;

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

            /// ViewModel = viweModel;

            DataContext = viewModel;
        }

        //private void NewButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.ResetSelected();
        //    CatName.Focus();
        //}

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.Save();
        //}

        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.Delete();
        //}

        private void CatName_OnKeyUp(object sender, KeyEventArgs e)
        {
            //ViewModel.IsSaveVisible = Visibility.Hidden;

            //if (!string.IsNullOrEmpty(CatName.Text.Trim()))
            //{
            //    ViewModel.IsSaveVisible = Visibility.Visible;
            //}
        }
    }
}