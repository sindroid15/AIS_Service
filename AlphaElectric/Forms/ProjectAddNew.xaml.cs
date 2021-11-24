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
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class ProjectAddNew : UserControl
    {
        ProjectViewModel _vm;
        BackgroundWorker worker;

        List<AIS_DataAccessLayer.Panel> panelList = new ProductFactory().SelectAllPanel();
        List<ProductItem> productItemsList = new List<ProductItem>();

        public ProjectAddNew()
        {
            InitializeComponent();
            _vm = new ProjectViewModel();

            this.DataContext = _vm;

            _vm.DeliveryDate = DateTime.Now.AddDays(2);
            _vm.OrderDate = DateTime.Now;
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
 
            List<Employee> emplist = new EmployeeFactory().SelectByDesignation(5);
            List<OrderStatus> orderStatuslist = new OrderStatusFactory().SelectAll();

            this.Dispatcher.Invoke(() =>
            {
                CustomerComboBox.ItemsSource = contactlist;
                CustomerComboBox.DisplayMemberPath = "CompanyName";
                CustomerComboBox.SelectedValuePath = "ID";

                PanelComboBox.ItemsSource = panelList;
                PanelComboBox.DisplayMemberPath = "SerialNo";
                PanelComboBox.SelectedValuePath = "ID";

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
            this.NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.DeliveryDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            this.OrderDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            this.DeliveryDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(NameTextBox) ||
                Validation.GetHasError(DeliveryDateDatePicker) ||
                Validation.GetHasError(OrderDateDatePicker))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заролни все поля" }
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
                    "Выбери все" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

 
            Project proj = new Project()
            {
                Name = NameTextBox.Text,
                DeliveyDate = DeliveryDateDatePicker.SelectedDate.Value
            };

 
            CustomerOrder co = new CustomerOrder()
            {
                OrderDate = OrderDateDatePicker.SelectedDate.Value,
                DeliveryDate = proj.DeliveyDate,
                ContactID = int.Parse(CustomerComboBox.SelectedValue.ToString()),
                OrderStatusID = int.Parse(OrderStatusComboBox.SelectedValue.ToString()),
                EmployeeID = int.Parse(AssignedEmployeeComboBox.SelectedValue.ToString())
            };

            new CustomerOrderFactory().InsertCustomerOrder(co);

 
            proj.CustomerOrderID = co.ID;
            new ProjectFactory().InsertProject(proj);

 
            using (var db = new AlphaElectricEntitiesDB())
            {
 
                foreach (var item in productItemsList)
                {
                    Panel_ProjectBT proj_panel = new Panel_ProjectBT()
                    {
                        PanelID = item.ProductID,
                        ProjectID = proj.ID   
                    };

                    
                    var query = from row in db.Panel_ProjectBT
                                where row.ProjectID == proj.ID
                                && row.PanelID == proj_panel.PanelID
                                select row;

                    if (query.ToList().Count == 0)
                    {
                        proj_panel.Quantity = item.Quantity;
                        db.Panel_ProjectBT.Add(proj_panel);
                        db.SaveChanges();
                    
                    }
                    else if (query.ToList().Count == 1)
                    {
                        foreach (var xx in query)
                        {
                            xx.Quantity += item.Quantity;
                        }
                        db.SaveChanges();
                    
                    }
                }
                productItemsList.Clear();
                ClearItems();
                Clear();

                if (true)
                {
                    var sMessageDialog = new MessageDialog
                    {
                        Message = { Text = "Проект добавлен" }
                    };

                    DialogHost.Show(sMessageDialog, "RootDialog");
                    ClearButton_Click(null,null);
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
                    "ERROR: Enter valid Quantity!" }
                };
            
                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (PanelComboBox.SelectedValue == null ||
                int.Parse(QuantityTextBox.Text) <= 0 ||
                (PanelComboBox.SelectedValue == null && int.Parse(QuantityTextBox.Text) <= 0) ||
                (int.Parse(QuantityTextBox.Text) >= 0 && PanelComboBox.SelectedValue == null))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "ERROR: Select Product and Add Quantity\n(positive number)!" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            ProductItem newItem = new ProductItem()
            {
                ProductID = int.Parse(PanelComboBox.SelectedValue.ToString()),
                Quantity = int.Parse(QuantityTextBox.Text)
            };

            
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
            
            DataGrid.ItemsSource = (from prod in panelList
                                    join prodwithQty in productItemsList
                                      on prod.ID equals prodwithQty.ProductID
                                    select new
                                    {
                                        prod.Name,
                                        prod.SerialNo,
                                        prod.Make,
                                        prod.Type,
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
            this.NameTextBox.Clear();

            OrderDateDatePicker.SelectedDate = null;
            DeliveryDateDatePicker.SelectedDate = null;

            CustomerComboBox.SelectedItem = null;
            AssignedEmployeeComboBox.SelectedItem = null;
            OrderStatusComboBox.SelectedItem = null;

            DataGrid.ItemsSource = null;
        }

        private void ClearItems()
        {
            PanelComboBox.SelectedItem = null;
            this.QuantityTextBox.Clear();
        }
    }
}