#pragma checksum "..\..\..\Forms\HomeProjects.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4C516DE16E50CA9C45A4682F34B42F9ABCC1105E1FBE6B0AC4F41B3006D9D3EC"
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
using AIS_DataAccessLayer;
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
    /// HomeProjects
    /// </summary>
    public partial class HomeProjects : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\Forms\HomeProjects.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UserPages;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Forms\HomeProjects.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid topgrid;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Forms\HomeProjects.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer mainscrollviewer;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Forms\HomeProjects.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonEmployees;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\Forms\HomeProjects.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCompanies;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\Forms\HomeProjects.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPurchaseSelling;
        
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
            System.Uri resourceLocater = new System.Uri("/AIS;component/forms/homeprojects.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\HomeProjects.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 22 "..\..\..\Forms\HomeProjects.xaml"
            ((AIS.Forms.HomeProjects)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserPages = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.topgrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.mainscrollviewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.ButtonEmployees = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\Forms\HomeProjects.xaml"
            this.ButtonEmployees.Click += new System.Windows.RoutedEventHandler(this.ButtonViewProjects_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonCompanies = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\..\Forms\HomeProjects.xaml"
            this.ButtonCompanies.Click += new System.Windows.RoutedEventHandler(this.ButtonUpdateProject_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonPurchaseSelling = ((System.Windows.Controls.Button)(target));
            
            #line 161 "..\..\..\Forms\HomeProjects.xaml"
            this.ButtonPurchaseSelling.Click += new System.Windows.RoutedEventHandler(this.ButtonAddNewProject_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

