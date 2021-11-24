using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
//using DevExpress.Xpf.Printing;

namespace AIS.Forms
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomeEmployees : UserControl
    {
        public HomeEmployees()
        {
            InitializeComponent();
            
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        

        #region main-buttons

        private void ButtonEmployees_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCompanies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonProjects_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPurchaseSelling_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        

        private void ButtonViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            this.topgrid.Visibility = Visibility.Collapsed;
            this.mainscrollviewer.Visibility = Visibility.Collapsed;

            EmployeeList x = new EmployeeList();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }

        private void ButtonUpdateEmployees_Click(object sender, RoutedEventArgs e)
        {
            this.topgrid.Visibility = Visibility.Collapsed;
            this.mainscrollviewer.Visibility = Visibility.Collapsed;

            EmployeeEdit x = new EmployeeEdit();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }

        private void ButtonAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.topgrid.Visibility = Visibility.Collapsed;
            this.mainscrollviewer.Visibility = Visibility.Collapsed;

            EmployeeAddNew x = new EmployeeAddNew();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }

       
    }
}
