using AIS_DataAccessLayer.Factories;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace AIS.Forms
{
    /// <summary>
    /// Interaction logic for CompanyList.xaml
    /// </summary>
    public partial class ProdStockList : UserControl
    {
        public ProdStockList()
        {
            InitializeComponent();
            LoadData();
            PopupBox.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void LoadData()
        {
            DataGrid.ItemsSource = new InventoryFactory().SelectAll();
        }

        private void PopUp_AddNewCompany(object sender, RoutedEventArgs e)
        {
           


            TextBlock_TitleName.Visibility = Visibility.Collapsed;
            DataGrid.Visibility = Visibility.Collapsed;
            PopupBox.Visibility = Visibility.Collapsed;

            ProductAddNew x = new ProductAddNew();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
            PopupBoxWithClose.Visibility = Visibility.Visible;
        }

        private void PopUp_Close(object sender, RoutedEventArgs e)
        {
            UserPages.Children.Clear();
            PopupBoxWithClose.Visibility = Visibility.Hidden;

            LoadData();
            TextBlock_TitleName.Visibility = Visibility.Visible;
            DataGrid.Visibility = Visibility.Visible;
            PopupBox.Visibility = Visibility.Visible;
        }

    }
}
    