﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;

using AIS_DataAccessLayer;
using AIS_DataAccessLayer.Factories;
using ViewModels;

namespace AIS.Forms
{
    class ProductItem
    {
        public int Quantity { get; set; }
        public int ProductID { get; set; }

        public ProductItem()
        {
            this.Quantity = 0;
            this.ProductID = 0;
        }
    }

    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class PurchaseOrderAdd : UserControl
    {
        PurchaseOrderViewModel _vm;
        
        BackgroundWorker worker;
        PurchaseOrder po = new PurchaseOrder();
        List<ProductItem> productItemsList = new List<ProductItem>();

        public PurchaseOrderAdd()
        {
            InitializeComponent();
            _vm = new PurchaseOrderViewModel();
            this.DataContext = _vm;
            _vm.PODate = DateTime.Now;
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Contact> contactlist = new ContactFactory().SelectAll();
            List<Product> prodlist = new ProductFactory().SelectAll();

            this.Dispatcher.Invoke(() =>
            {
                SupplierComboBox.ItemsSource = contactlist;
                SupplierComboBox.DisplayMemberPath = "CompanyName";
                SupplierComboBox.SelectedValuePath = "ID";

                ProductComboBox.ItemsSource = prodlist;
                ProductComboBox.DisplayMemberPath = "SerialNo";
                ProductComboBox.SelectedValuePath = "ID";
            });
        }

        private void ForceValidation()
        {
            this.PODateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(PODateDatePicker))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заполни все поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (SupplierComboBox.SelectedValue == null)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заполни все поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (productItemsList.Count() == 0)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Нет товаров в заказе,\nдобавьте!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

        
            po.PODate = PODateDatePicker.SelectedDate.Value;
            po.ContactID = int.Parse(SupplierComboBox.SelectedValue.ToString());
            PurchaseOrderFactory fac = new PurchaseOrderFactory();
            fac.InsertPurchaseOrder(po);

        
            using (var db = new AlphaElectricEntitiesDB())
            {
                bool flag = false;
        
                foreach (var item in productItemsList)
                {
                    Product_PurchaseOrderBT po_prod = new Product_PurchaseOrderBT()
                    {
                        ProductID = item.ProductID,
                        PurchaseOrderID = po.ID
                    };

        
                    var query = from prod in db.Product_PurchaseOrderBT
                                where prod.PurchaseOrderID == po.ID
                                && prod.ProductID == po_prod.ProductID
                                select prod;

                    if (query.ToList().Count == 0)
                    {
                        po_prod.Quantity = item.Quantity;
                        db.Product_PurchaseOrderBT.Add(po_prod);
                        db.SaveChanges();
                        flag = true;
                    }
                    else if (query.ToList().Count == 1)
                    {
                        foreach (var xx in query)
                        {
                            xx.Quantity += item.Quantity;
                        }
                        db.SaveChanges();
                        flag = true;
                    }
                }
                productItemsList.Clear();
                ClearItems();
                Clear();

                if (flag)
                {
                    var sMessageDialog = new MessageDialog
                    {
                        Message = { Text = "Заказ добавлен" }
                    };
                    DialogHost.Show(sMessageDialog, "RootDialog");
                    return;
                }
            }
        }

        private void InsertItem_Click(object sender, RoutedEventArgs e)
        {
            #region validation
            if (string.IsNullOrEmpty(QuantityTextBox.Text) || !(int.TryParse(QuantityTextBox.Text, out int a)))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Некорректное количество" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (ProductComboBox.SelectedValue == null || int.Parse(QuantityTextBox.Text) <= 0)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Выбери товар и количество\n(положительное число)!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            ProductItem item = new ProductItem()
            {
                ProductID = int.Parse(ProductComboBox.SelectedValue.ToString()),
                Quantity = int.Parse(QuantityTextBox.Text)
            };
            productItemsList.Add(item);
            ClearItems();

            if (true)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Добавлено" }
                };
                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            ClearItems();
            productItemsList.Clear();
        }

        private void Clear()
        {
            SupplierComboBox.SelectedItem = null;
            this.PODateDatePicker.SelectedDate = null;
        }

        private void ClearItems()
        {
            ProductComboBox.SelectedItem = null;
            this.QuantityTextBox.Clear();
        }
    }
}