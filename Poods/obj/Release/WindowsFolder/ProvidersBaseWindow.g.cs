﻿#pragma checksum "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD60727AF0B45F033240485198A9301DDFC167011AC8BE528B072A6E305F6B42"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Poods.WindowsFolder;
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


namespace Poods.WindowsFolder {
    
    
    /// <summary>
    /// ProvidersBaseWindow
    /// </summary>
    public partial class ProvidersBaseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridProvider;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ContactPersonTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxIdProvider;
        
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
            System.Uri resourceLocater = new System.Uri("/Poods;component/windowsfolder/providersbasewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
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
            this.DataGridProvider = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            
            #line 21 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Provider_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update_Provider_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ContactPersonTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.AddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 33 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delet_Provider_Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ComboBoxIdProvider = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 36 "..\..\..\WindowsFolder\ProvidersBaseWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update_DataGrid_Provider_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

