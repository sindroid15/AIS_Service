﻿#pragma checksum "..\..\..\Forms\CustomerOrderAdd.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6AA9C679D7C33E3621B0B7270DACB7756CF46C32B77A8EA93EA31D4B8797FCEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AIS.Forms;
using AIS.Logic;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AIS.Forms {
    
    
    /// <summary>
    /// CustomerOrderAdd
    /// </summary>
    public partial class CustomerOrderAdd : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 131 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker OrderDateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DeliveryDateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CustomerComboBox;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProductComboBox;
        
        #line default
        #line hidden
        
        
        #line 266 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuantityTextBox;
        
        #line default
        #line hidden
        
        
        #line 300 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AssignedEmployeeComboBox;
        
        #line default
        #line hidden
        
        
        #line 324 "..\..\..\Forms\CustomerOrderAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox OrderStatusComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AIS;component/forms/customerorderadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\CustomerOrderAdd.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 22 "..\..\..\Forms\CustomerOrderAdd.xaml"
            ((AIS.Forms.CustomerOrderAdd)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.OrderDateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.DeliveryDateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.CustomerComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ProductComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.QuantityTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 283 "..\..\..\Forms\CustomerOrderAdd.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.InsertItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AssignedEmployeeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.OrderStatusComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 347 "..\..\..\Forms\CustomerOrderAdd.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 353 "..\..\..\Forms\CustomerOrderAdd.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

