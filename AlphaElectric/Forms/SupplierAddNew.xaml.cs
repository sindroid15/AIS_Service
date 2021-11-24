using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;


using AIS_DataAccessLayer;
using AIS_DataAccessLayer.Factories;
using ViewModels;

namespace AIS.Forms
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class SupplierAddNew : UserControl
    {
        ContactViewModel _vm;
        
        BackgroundWorker worker;

        public SupplierAddNew()
        {
            InitializeComponent();

            _vm = new ContactViewModel();
            this.DataContext = _vm;
        }

        //Executing after loading window, refer to XAML
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {

            });
        }

        private void ForceValidation()
        {
            this.NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.AddressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.EmailTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.PhoneNoTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(NameTextBox) || Validation.GetHasError(AddressTextBox) || Validation.GetHasError(EmailTextBox) || Validation.GetHasError(PhoneNoTextBox))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заполни все поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            Contact comp = new Contact();
            comp.CompanyName = NameTextBox.Text;
            comp.Phone = PhoneNoTextBox.Text;
            comp.Email = EmailTextBox.Text;
            comp.Address = AddressTextBox.Text;

            ContactFactory fac = new ContactFactory();
            if (fac.InsertContact(comp))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Успешно добавлено!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                Clear();
                return;
            }
            else
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Невозможно добавить" }
                };
                DialogHost.Show(sMessageDialog, "RootDialog");
                Clear();
                return;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            this.NameTextBox.Clear();
            this.AddressTextBox.Clear();
            this.EmailTextBox.Clear();
            this.PhoneNoTextBox.Clear();
        }
    }
}
