using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using AIS.Logic;

namespace AIS.Forms
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            WelcomeMessage.Text = "Добро пожаловать, " + LoggedInUser.Instance.Info.Name + "!";
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        

        #region main-buttons

        private void ButtonEmployees_Click(object sender, RoutedEventArgs e)
        {
            this.mainscrollviewer.Visibility = Visibility.Collapsed;
            this.topgrid.Visibility = Visibility.Collapsed;
            


            HomeEmployees x = new HomeEmployees();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }

        private void ButtonProducts_Click(object sender, RoutedEventArgs e)
        {
            this.mainscrollviewer.Visibility = Visibility.Collapsed;
            this.topgrid.Visibility = Visibility.Collapsed;
            

            HomeProducts x = new HomeProducts();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }

        private void ButtonCompanies_Click(object sender, RoutedEventArgs e)
        {
            this.mainscrollviewer.Visibility = Visibility.Collapsed;
            this.topgrid.Visibility = Visibility.Collapsed;
            

            HomeCompanies x = new HomeCompanies();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }

        private void ButtonProjects_Click(object sender, RoutedEventArgs e)
        {
            this.mainscrollviewer.Visibility = Visibility.Collapsed;
            this.topgrid.Visibility = Visibility.Collapsed;
            

            HomeProjects x = new HomeProjects();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }

        private void ButtonPurchaseSelling_Click(object sender, RoutedEventArgs e)
        {
            this.mainscrollviewer.Visibility = Visibility.Collapsed;
            this.topgrid.Visibility = Visibility.Collapsed;
            

            HomePurchaseSelling x = new HomePurchaseSelling();
            UserPages.Children.Clear();
            UserPages.Children.Add(x);
        }
        #endregion

        
    }
}
