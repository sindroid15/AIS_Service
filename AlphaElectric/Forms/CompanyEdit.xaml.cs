﻿using System.Collections.Generic;
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
    public partial class CompanyEdit : UserControl
    {
        ContactViewModel _vm;
        //Adding backgroud worker
        BackgroundWorker worker;
        List<Contact> conlist;


        public CompanyEdit()
        {
            InitializeComponent();

            _vm = new ContactViewModel();
            this.DataContext = _vm;
        }

        void UpdateFields()
        {
            if (SelectCompanyComboBox.SelectedValue != null)
            {
                var db = new AlphaElectricEntitiesDB();
                var id = int.Parse(SelectCompanyComboBox.SelectedValue.ToString());
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

        //Executing after loading window, refer to XAML
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
                SelectCompanyComboBox.ItemsSource = conlist;
                SelectCompanyComboBox.DisplayMemberPath = "CompanyName";
                SelectCompanyComboBox.SelectedValuePath = "ID";
            });
        }

        private void ForceValidation()
        {
            //this.SelectCustomerComboBox.SelectedItem = null;
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
                    Message = { Text = "Заполните все поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (SelectCompanyComboBox.SelectedItem == null)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Выберите компанию для редактирования !" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            ContactFactory fac = new ContactFactory();
            if (fac.Update(int.Parse(SelectCompanyComboBox.SelectedValue.ToString()),
                NameTextBox.Text,
                PhoneTextBox.Text,
                EmailTextBox.Text,
                AddressTextBox.Text))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Успешно обновлено" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                Clear();
                conlist = new ContactFactory().SelectAll();
            }
            else
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Успешно обновлено" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            this.SelectCompanyComboBox.SelectedItem = null;
            this.NameTextBox.Clear();
            this.EmailTextBox.Clear();
            this.PhoneTextBox.Clear();
            this.AddressTextBox.Clear();        }

        private void SelectCompanyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFields();
        }
    }
}