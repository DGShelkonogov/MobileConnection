﻿#pragma checksum "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "493489739A80F9C803620E31079028421807949D"
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
    /// TypeOfCallsAndMessagesPage
    /// </summary>
    public partial class TypeOfCallsAndMessagesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTitle;
        
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
            System.Uri resourceLocater = new System.Uri("/MobileConnection;component/pages/admin/typeofcallsandmessagespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
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
            
            #line 26 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Search);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dtg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 29 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
            this.dtg.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.dtg_MouseUp);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
            this.dtg.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.dataGrid_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbxTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 56 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Back);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 57 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Add);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 58 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Edit);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 59 "..\..\..\..\..\Pages\Admin\TypeOfCallsAndMessagesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

