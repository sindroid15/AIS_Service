﻿using System.Collections.Generic;
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
    public partial class SupplierEdit : UserControl
    {
        ContactViewModel _vm;
        
        BackgroundWorker worker;
        List<Contact> conlist;


        public SupplierEdit()
        {
            InitializeComponent();

            _vm = new ContactViewModel();
            this.DataContext = _vm;
        }

        void UpdateFields()
        {
            if (SelectSupplierComboBox.SelectedValue != null)
            {
                var db = new AlphaElectricEntitiesDB();
                var id = int.Parse(SelectSupplierComboBox.SelectedValue.ToString());
                var cust = db.Contacts.Where(x => x.ID == id).FirstOrDefault();
                if (cust != null)
                {
                    NameTextBox.Text = cust.CompanyName;
                    EmailTextBox.Text = cust.Email;
                    PhoneTextBox.Text = cust.Phone;
                    AddressTextBox.Text = cust.Address;
               }
            }
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            conlist = new ContactFactory().SelectAll();
            this.Dispatcher.Invoke(() =>
            {
                SelectSupplierComboBox.ItemsSource = conlist;
                SelectSupplierComboBox.DisplayMemberPath = "CompanyName";
                SelectSupplierComboBox.SelectedValuePath = "ID";
            });
        }

        private void ForceValidation()
        {
            
            this.NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.EmailTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.PhoneTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.AddressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(NameTextBox) ||
                Validation.GetHasError(EmailTextBox) ||
                Validation.GetHasError(PhoneTextBox) ||
                Validation.GetHasError(AddressTextBox))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заполни все поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            if (SelectSupplierComboBox.SelectedItem == null)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Выбери поставщика" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            ContactFactory fac = new ContactFactory();
            if (fac.Update(int.Parse(SelectSupplierComboBox.SelectedValue.ToString()),
                NameTextBox.Text,
                PhoneTextBox.Text,
                EmailTextBox.Text,
                AddressTextBox.Text))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Обновление успешно" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                Clear();
                conlist = new ContactFactory().SelectAll();
            }
            else
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Не обновлено" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            this.SelectSupplierComboBox.SelectedItem = null;
            this.NameTextBox.Clear();
            this.EmailTextBox.Clear();
            this.PhoneTextBox.Clear();
            this.AddressTextBox.Clear();
        }

        private void SelectSupplierComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFields();
        }
    }
}