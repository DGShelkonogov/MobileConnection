﻿#pragma checksum "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7E7BCCE81BAE43983026485387ABC6659D7BC47A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MobileConnection.Pages.Admin;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace MobileConnection.Pages.Admin {
    
    
    /// <summary>
    /// CorporateClientPage
    /// </summary>
    public partial class CorporateClientPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClients;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbINN;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCompany_Name;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbLegal_Adsress;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPhysical_Adsress;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPersonal_Account_Number;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MobileConnection;component/pages/admin/corporateclientpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 25 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Search);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dtg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 28 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            this.dtg.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.dtg_MouseUp);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            this.dtg.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.dataGrid_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 80 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Back);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 90 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Add);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 91 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Edit);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 92 "..\..\..\..\..\Pages\Admin\CorporateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Delete);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmbClients = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.txbINN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txbCompany_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txbLegal_Adsress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.txbPhysical_Adsress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txbPersonal_Account_Number = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

