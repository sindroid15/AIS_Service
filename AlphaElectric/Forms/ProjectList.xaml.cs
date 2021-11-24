using AIS_DataAccessLayer.Factories;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace AIS.Forms
{
    /// <summary>
    /// Interaction logic for CompanyList.xaml
    /// </summary>
    public partial class ProjectList : UserControl
    {
        public ProjectList()
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
            var dataList = new Panel_ProjectBTFactory().SelectAll();

            foreach (var row in dataList)
            {
                row.Project.CustomerOrder.Employee.FirstName = 
                    row.Project.CustomerOrder.Employee.FirstName + " "
                    + row.Project.CustomerOrder.Employee.LastName;
            };

            DataGrid.ItemsSource = dataList;
        }

        private void PopUp_AddNewCompany(object sender, RoutedEventArgs e)
        {
           


            TextBlock_TitleName.Visibility = Visibility.Collapsed;
            DataGrid.Visibility = Visibility.Collapsed;
            PopupBox.Visibility = Visibility.Collapsed;

            ProjectAddNew x = new ProjectAddNew();
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

        private void PopUp_EditCompany(object sender, RoutedEventArgs e)
        {
            TextBlock_TitleName.Visibility = Visibility.Collapsed;
            DataGrid.Visibility = Visibility.Collapsed;
            PopupBox.Visibility = Visibility.Collapsed;

            ProjectEdit x = new ProjectEdit();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
            PopupBoxWithClose.Visibility = Visibility.Visible;
        }
    }
}
    