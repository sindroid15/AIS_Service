﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;

// Added DA & Factories
using AIS_DataAccessLayer;
using AIS_DataAccessLayer.Factories;
using ViewModels;

namespace AIS.Forms
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class CustomerOrderAdd : UserControl
    {
        CustomerOrderViewModel _vm;
        //Adding backgroud worker
        BackgroundWorker worker;
        List<Product> prodList = new ProductFactory().SelectAll();
        List<ProductItem> productItemsList = new List<ProductItem>();

        public CustomerOrderAdd()
        {
            InitializeComponent();
            _vm = new CustomerOrderViewModel();
            this.DataContext = _vm;
            
            _vm.DeliveryDate = DateTime.Now.AddDays(1);
            _vm.OrderDate = DateTime.Now;
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
            List<Contact> contactlist = new ContactFactory().SelectAll();
            List<Product> prodlist = new ProductFactory().SelectAll();
            // 5 = 'Purchase/Sales Manager'
            List<Employee> emplist = new EmployeeFactory().SelectByDesignation(5);
            List<OrderStatus> orderStatuslist = new OrderStatusFactory().SelectAll();

            this.Dispatcher.Invoke(() =>
            {
                CustomerComboBox.ItemsSource = contactlist;
                CustomerComboBox.DisplayMemberPath = "CompanyName";
                CustomerComboBox.SelectedValuePath = "ID";

                ProductComboBox.ItemsSource = prodlist;
                ProductComboBox.DisplayMemberPath = "SerialNo";
                ProductComboBox.SelectedValuePath = "ID";

                AssignedEmployeeComboBox.ItemsSource = emplist;
                AssignedEmployeeComboBox.DisplayMemberPath = "FirstName";
                AssignedEmployeeComboBox.SelectedValuePath = "ID";

                OrderStatusComboBox.ItemsSource = orderStatuslist;
                OrderStatusComboBox.DisplayMemberPath = "Name";
                OrderStatusComboBox.SelectedValuePath = "ID";
            });
        }

        private void ForceValidation()
        {
            this.OrderDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            this.DeliveryDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(OrderDateDatePicker) || Validation.GetHasError(DeliveryDateDatePicker))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заполнены не все поля!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (CustomerComboBox.SelectedValue == null || 
                AssignedEmployeeComboBox.SelectedValue == null ||
                OrderStatusComboBox.SelectedValue == null)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заполнены не все поля!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (productItemsList.Count() == 0)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Нет в заказе,\nДобавьте!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            bool flag = false;

            // Creating PO 
            CustomerOrder co = new CustomerOrder()
            {
                OrderDate = OrderDateDatePicker.SelectedDate.Value,
                DeliveryDate = DeliveryDateDatePicker.SelectedDate.Value,
                ContactID = int.Parse(CustomerComboBox.SelectedValue.ToString()),
                OrderStatusID = int.Parse(OrderStatusComboBox.SelectedValue.ToString()),
                EmployeeID = int.Parse(AssignedEmployeeComboBox.SelectedValue.ToString())
            };

            //CustomerOrderFactory fac = new CustomerOrderFactory();
            //fac.InsertCustomerOrder(co);
            new CustomerOrderFactory().InsertCustomerOrder(co);

            // Adding Products to PO
            using (var db = new AlphaElectricEntitiesDB())
            {
                // Multiple Products
                foreach (var item in productItemsList)
                {
                    Product_CustomerOrderBT co_prod = new Product_CustomerOrderBT()
                    {
                        ProductID = item.ProductID,
                        CustomerOrderID = co.ID
                    };

                    // LINQ query
                    var query = from row in db.Product_CustomerOrderBT
                                where row.CustomerOrderID == co.ID
                                && row.ProductID == co_prod.ProductID
                                select row;

                    if (query.ToList().Count == 0)
                    {
                        co_prod.Quantity = item.Quantity;
                        db.Product_CustomerOrderBT.Add(co_prod);
                        db.SaveChanges();
                        flag = true;
                    }
                    // Checks if existing ProductID and PurchaseOrderID exists
                    // Used if item is added again
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
                    "Введите корректное количество" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (ProductComboBox.SelectedValue == null ||
                int.Parse(QuantityTextBox.Text) <= 0 ||
                (ProductComboBox.SelectedValue == null && int.Parse(QuantityTextBox.Text) <= 0) || 
                (int.Parse(QuantityTextBox.Text) >= 0 && ProductComboBox.SelectedValue == null))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Выберите продукт и количество\n(положительное число)!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            ProductItem newItem = new ProductItem()
            {
                ProductID = int.Parse(ProductComboBox.SelectedValue.ToString()),
                Quantity = int.Parse(QuantityTextBox.Text)
            };

            //If same item added again but with more quantity...
            var addedProduct = productItemsList.Where(x => x.ProductID == newItem.ProductID).FirstOrDefault();
            if (addedProduct != null)
                addedProduct.Quantity += newItem.Quantity;              
            else
                productItemsList.Add(newItem);
            ClearItems();
            LoadData();

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

        private void LoadData()
        {
            

            DataGrid.ItemsSource = (from prod in prodList
                                    join prodwithQty in productItemsList
                                      on prod.ID equals prodwithQty.ProductID
                                    select new
                                    {
                                        prod.Name,
                                        prod.SerialNo,
                                        prod.Make,
                                        prodwithQty.Quantity
                                    }).ToList();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            ClearItems();
            productItemsList.Clear();
        }

        private void Clear()
        {
            OrderDateDatePicker.SelectedDate = null;
            DeliveryDateDatePicker.SelectedDate = null;

            CustomerComboBox.SelectedItem = null;
            AssignedEmployeeComboBox.SelectedItem = null;
            OrderStatusComboBox.SelectedItem = null;

            DataGrid.ItemsSource = null;
        }

        private void ClearItems()
        {
            ProductComboBox.SelectedItem = null;
            this.QuantityTextBox.Clear();
        }
    }
}
