﻿#pragma checksum "..\..\..\..\View\HabitantView\HabitantMainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "378E207BDC563AB96730E8D58A90898DFF8360CE8C6F3C5DBDD1096050F51BEE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using RentCalculation.View.HabitantView;
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


namespace RentCalculation.View.HabitantView {
    
    
    /// <summary>
    /// HabitantMainPage
    /// </summary>
    public partial class HabitantMainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MeterReadingsButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InvoicesButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogoutButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AddressTextBlock;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AreaTextBlock;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LastReadingsGrid;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LastInvoicesGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/RentCalculation;component/view/habitantview/habitantmainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
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
            this.MeterReadingsButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
            this.MeterReadingsButton.Click += new System.Windows.RoutedEventHandler(this.MeterReadingsButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.InvoicesButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
            this.InvoicesButton.Click += new System.Windows.RoutedEventHandler(this.InvoicesButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LogoutButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\View\HabitantView\HabitantMainPage.xaml"
            this.LogoutButton.Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddressTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.AreaTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.LastReadingsGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.LastInvoicesGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

