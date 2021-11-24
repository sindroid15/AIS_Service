using System;
using System.Collections.Generic;
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
    public partial class EmployeeAddNew : UserControl
    {
        EmployeeViewModel _vm;
        
        BackgroundWorker worker;

        public EmployeeAddNew()
        {
            InitializeComponent();

            _vm = new EmployeeViewModel();
            this.DataContext = _vm;
            _vm.JoinDate = DateTime.Now;
            
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Designation> emplist = new DesignationFactory().SelectAll();
            List<EmployeeStatus> empStatusList = new EmployeeStatusFactory().SelectAll();
            this.Dispatcher.Invoke(() =>
            {
                DesignationComboBox.ItemsSource = emplist;
                DesignationComboBox.DisplayMemberPath = "Name";
                DesignationComboBox.SelectedValuePath = "ID";

                EmployeeStatusComboBox.ItemsSource = empStatusList;
                EmployeeStatusComboBox.DisplayMemberPath = "Name";
                EmployeeStatusComboBox.SelectedValuePath = "ID";
            });
        }

        private void ForceValidation()
        {
            this.FirstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.LastNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.PhoneTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.PassportTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.JoinDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            this.AddressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.DesignationComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            this.EmployeeStatusComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(FirstNameTextBox) ||
                Validation.GetHasError(LastNameTextBox) || 
                Validation.GetHasError(PhoneTextBox) || 
                Validation.GetHasError(PassportTextBox) ||
                Validation.GetHasError(JoinDateDatePicker) ||
                 Validation.GetHasError(AddressTextBox)) 
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Заполните все поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (DesignationComboBox.SelectedItem == null || DesignationComboBox.SelectedItem == null)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Выберите обозначение и статус" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }
            #endregion

            Employee emp = new Employee();
            emp.FirstName = FirstNameTextBox.Text;
            emp.LastName = LastNameTextBox.Text;
            emp.Phone = PhoneTextBox.Text;
            emp.Passport = PassportTextBox.Text;
            emp.JoinDate = JoinDateDatePicker.SelectedDate.Value;
            emp.Address = AddressTextBox.Text;
            emp.DesignationID = int.Parse(DesignationComboBox.SelectedValue.ToString());
            emp.EmployeeStatusID = int.Parse(EmployeeStatusComboBox.SelectedValue.ToString());

            if (new EmployeeFactory().InsertEmployee(emp))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Успешно добавлено" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                Clear();
                return;
            }
            else
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Невозможно добавить" }
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
            this.FirstNameTextBox.Clear();
            this.LastNameTextBox.Clear();
            this.PhoneTextBox.Clear();
            this.PassportTextBox.Clear();
            this.JoinDateDatePicker.SelectedDate = null;
            this.AddressTextBox.Clear();
            this.DesignationComboBox.SelectedItem = null;
            this.EmployeeStatusComboBox.SelectedItem = null;
        }
    }
}
