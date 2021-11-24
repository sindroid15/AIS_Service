using System;
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
    public partial class ProjectEdit : UserControl
    {
        ProjectViewModel _vm;
        
        BackgroundWorker worker;
        List<Project> projlist;


        public ProjectEdit()
        {
            InitializeComponent();

            _vm = new ProjectViewModel();
            this.DataContext = _vm;
            _vm.DeliveryDate = DateTime.Now;
        }

        void UpdateFields()
        {
            if (SelectProjectComboBox.SelectedValue != null)
            {
                var id = int.Parse(SelectProjectComboBox.SelectedValue.ToString());
                var proj = new AlphaElectricEntitiesDB().Projects.Where(x => x.ID == id).FirstOrDefault();
                if (proj != null)
                {
                    NameTextBox.Text = proj.Name;
                    this.DeliveryDateDatePicker.SelectedDate = proj.DeliveyDate;
                    OrderStatusComboBox.SelectedValue = proj.CustomerOrder.OrderStatusID;
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
            projlist = new ProjectFactory().SelectAll();
            var orderStatusList = new OrderStatusFactory().SelectAll();

            
            this.Dispatcher.Invoke(() =>
            {
                SelectProjectComboBox.ItemsSource = projlist;
                SelectProjectComboBox.DisplayMemberPath = "Name";
                SelectProjectComboBox.SelectedValuePath = "ID";

                OrderStatusComboBox.ItemsSource = orderStatusList;
                OrderStatusComboBox.DisplayMemberPath = "Name";
                OrderStatusComboBox.SelectedValuePath = "ID";

            });
        }

        private void ForceValidation()
        {

            this.DeliveryDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            this.NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            #region validation 
            ForceValidation();
            if (Validation.GetHasError(NameTextBox) ||
                Validation.GetHasError(DeliveryDateDatePicker))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Заполни все поля" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if (SelectProjectComboBox.SelectedItem == null)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Выбери проект для редактирования" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            if ( OrderStatusComboBox.SelectedItem == null)
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text = "Выбери статус" }
                };

                DialogHost.Show(sMessageDialog, "RootDialog");
                return;
            }

            #endregion

            if (new ProjectFactory().Update(int.Parse(SelectProjectComboBox.SelectedValue.ToString()),
                NameTextBox.Text,
                int.Parse(OrderStatusComboBox.SelectedValue.ToString()),
                DeliveryDateDatePicker.SelectedDate.Value))
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Обновлено!" }
                };
                DialogHost.Show(sMessageDialog, "RootDialog");
                Clear();
                projlist = new ProjectFactory().SelectAll();
                return;
            }
            else
            {
                var sMessageDialog = new MessageDialog
                {
                    Message = { Text =
                    "Не обновлено" }
                };
                DialogHost.Show(sMessageDialog, "RootDialog");
                Clear();
                projlist = new ProjectFactory().SelectAll();
                return;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            this.SelectProjectComboBox.SelectedItem = null;
            this.OrderStatusComboBox.SelectedItem = null;
            this.NameTextBox.Clear();

        }

        private void SelectProjectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFields();
        }
    }
}