#pragma checksum "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B6F66AE966009B2D8F078C05A8228A2AAF8B3E57"
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
    /// PrivateClientPage
    /// </summary>
    public partial class PrivateClientPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClients;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbClient_Surname;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbClient_Name;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbClient_Patronymic;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbDate_Of_Birth;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPassport_Series;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPassport_Number;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbAdsress;
        
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
            System.Uri resourceLocater = new System.Uri("/MobileConnection;component/pages/admin/privateclientpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
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
            
            #line 24 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Search);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dtg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
            this.dtg.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.dtg_MouseUp);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
            this.dtg.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.dataGrid_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 91 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Back);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 101 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Add);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 102 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Edit);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 103 "..\..\..\..\..\Pages\Admin\PrivateClientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Delete);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmbClients = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.txbClient_Surname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txbClient_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txbClient_Patronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.txbDate_Of_Birth = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txbPassport_Series = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txbPassport_Number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txbAdsress = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

