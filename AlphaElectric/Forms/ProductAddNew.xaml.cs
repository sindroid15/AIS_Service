using System.Collections.Generic;
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
    public partial class ProductAddNew : UserControl
    {
        ProductViewModel _vm;
        BackgroundWorker worker;

        public ProductAddNew()
        {
            InitializeComponent();

            _vm = new ProductViewModel();
            this.DataContext = _vm;
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Make> mklist = new MakeFactory().SelectAll();
            List<AIS_DataAccessLayer.Type> paneltypelist = new TypeFactory().SelectAll();
            List<SizeType> szlist = new SizeTypeFactory().SelectAll();
            List<PanelShellGradeProtection> shellgradelist = new PanelShellGradeProtectionFactory().SelectAll();
            List<Certification> certlist = new CertificationFactory().SelectAll();
            List<PaType> parttypelist = new PaTypeFactory().SelectAll();
            List<Location> locationlist = new LocationFactory().SelectAll();

            this.Dispatcher.Invoke(() =>
            {
                
                MakeComboBox.ItemsSource = mklist;
                MakeComboBox.DisplayMemberPath = "Name";
                MakeComboBox.SelectedValuePath = "ID";

                
                PanelTypeComboBox.ItemsSource = paneltypelist;
                PanelTypeComboBox.DisplayMemberPath = "Description";
                PanelTypeComboBox.SelectedValuePath = "ID";

                SizeComboBox.ItemsSource = szlist;
                SizeComboBox.DisplayMemberPath = "Description";
                SizeComboBox.SelectedValuePath = "ID";

                PanelIPNumberComboBox.ItemsSource = shellgradelist;
                PanelIPNumberComboBox.DisplayMemberPath = "IPNum";
                PanelIPNumberComboBox.SelectedValuePath = "ID";

                CertComboBox.ItemsSource = certlist;
                CertComboBox.DisplayMemberPath = "Name";
                CertComboBox.SelectedValuePath = "ID";

                
                PartTypeComboBox.ItemsSource = parttypelist;
                PartTypeComboBox.DisplayMemberPath = "Name";
                PartTypeComboBox.SelectedValuePath = "ID";

                
                LocationComboBox.ItemsSource = locationlist;
                LocationComboBox.DisplayMemberPath = "Name";
                LocationComboBox.SelectedValuePath = "ID";
            });
        }

        private void P_Panel_Checked(object sender, RoutedEventArgs e)
        {
            
            TxtBxStackPanel4.Visibility = Visibility.Collapsed;

            
            TxtBxStackPanel0.Visibility = Visibility.Visible;
            TxtBxStackPanel1.Visibility = Visibility.Visible;
            TxtBxStackPanel2.Visibility = Visibility.Visible;
            TxtBxStackPanel3.Visibility = Visibility.Visible;
        }

        private void P_Product_Checked(object sender, RoutedEventArgs e)
        {
            
            TxtBxStackPanel4.Visibility = Visibility.Visible;

            
            TxtBxStackPanel0.Visibility = Visibility.Collapsed;
            TxtBxStackPanel1.Visibility = Visibility.Collapsed;
            TxtBxStackPanel2.Visibility = Visibility.Collapsed;
            TxtBxStackPanel3.Visibility = Visibility.Collapsed;
        }

        private void ForceValidation()
        {
            NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            SerialNoTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            StockLevelTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }


        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(NameTextBox) || Validation.GetHasError(SerialNoTextBox) || Validation.GetHasError(StockLevelTextBox))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Не заполнены поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            else if (!(bool)P_Panel.IsChecked && !(bool)P_Part.IsChecked)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Выберите другую часть" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            else if ((bool)P_Panel.IsChecked)
            {
                if (MakeComboBox.SelectedValue == null ||
                    LocationComboBox.SelectedValue == null ||
                    PanelTypeComboBox.SelectedValue == null ||
                    SizeComboBox.SelectedValue == null ||
                    PanelIPNumberComboBox.SelectedValue == null ||
                    CertComboBox.SelectedValue == null
                    )
                {
                    var sMessageDialog = new MessageDialog
                    {
                        Message = { Text =
                    "Не все поля заполнены" }
                    };

                    DialogHost.Show(sMessageDialog, "RootDialog");
                    return;
                }
            }
            else if ((bool)P_Part.IsChecked)
            {
                if (MakeComboBox.SelectedValue == null ||
                    LocationComboBox.SelectedValue == null ||
                    PartTypeComboBox.SelectedValue == null
                    )
                {
                    var sMessageDialog = new MessageDialog
                    {
                        Message = { Text =
                    "Выберите все поля" }
                    };

                    DialogHost.Show(sMessageDialog, "RootDialog");
                    return;
                }
            }

            #endregion

            if ((bool)P_Panel.IsChecked)
            {
                AIS_DataAccessLayer.Panel panel = new AIS_DataAccessLayer.Panel()
                {
                    Name = NameTextBox.Text,
                    SerialNo = SerialNoTextBox.Text,
                    MakeID = int.Parse(MakeComboBox.SelectedValue.ToString()),
                    TypeID = int.Parse(PanelTypeComboBox.SelectedValue.ToString()),
                    SizeTypeID = int.Parse(SizeComboBox.SelectedValue.ToString()),
                    PanelShellGradeProtectionIPNumber = int.Parse(PanelIPNumberComboBox.SelectedValue.ToString()),
                    CertificationID = int.Parse(CertComboBox.SelectedValue.ToString())
                };

                Product incomingNewProduct = new AIS_DataAccessLayer.Panel();
                incomingNewProduct = panel;
                AddProd(incomingNewProduct);
                AddProdToLocation(incomingNewProduct,
                    int.Parse(StockLevelTextBox.Text),
                    int.Parse(LocationComboBox.SelectedValue.ToString()));
            }

            if ((bool)P_Part.IsChecked)
            {
                Part part = new AIS_DataAccessLayer.Part()
                {
                    Name = NameTextBox.Text,
                    SerialNo = SerialNoTextBox.Text,
                    MakeID = int.Parse(MakeComboBox.SelectedValue.ToString()),

                    PaTypeID = int.Parse(PartTypeComboBox.SelectedValue.ToString())
                };

                Product incomingNewProduct = new Part();
                incomingNewProduct = part;
                AddProd(incomingNewProduct);
                AddProdToLocation(incomingNewProduct, 
                    int.Parse(StockLevelTextBox.Text), 
                    int.Parse(LocationComboBox.SelectedValue.ToString()));
            }

            ClearButton_Click(null, null);
        }

        private void AddProdToLocation(Product prod, int stockLevel, int locID)
        {
            var inven = new Inventory()
            {
                ID = prod.ID,
                StockLevel = stockLevel,
                LocationID = locID,
            };
            new InventoryFactory().InsertInventory(inven);
        }

        private void AddProd(Product incomingNewProduct)
        {
            if (new ProductFactory().InsertProduct(incomingNewProduct))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Успешно добавлено" }
                };
                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            else
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Не удается" }
                };
                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Clear();
            StockLevelTextBox.Clear();
            SerialNoTextBox.Clear();

            MakeComboBox.SelectedItem = null;
            CertComboBox.SelectedItem = null;
            PanelIPNumberComboBox.SelectedItem = null;
            SizeComboBox.SelectedItem = null;
            PanelTypeComboBox.SelectedItem = null;
            PartTypeComboBox.SelectedItem = null;
            LocationComboBox.SelectedItem = null;
        }
    }
}
