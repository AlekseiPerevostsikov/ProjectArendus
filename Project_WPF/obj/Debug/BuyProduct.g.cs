﻿#pragma checksum "..\..\BuyProduct.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2A28484BE7D170B8BE519C3CC5EFB697"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_WPF;
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


namespace Project_WPF {
    
    
    /// <summary>
    /// BuyProduct
    /// </summary>
    public partial class BuyProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productlList;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProdyctQuntity;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddToBasket;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView basketList;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductName;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductNameInBasket;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteFromBasket;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirmBasket;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSubCategoryName;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCategoryName;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProductQuantityInBasket;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\BuyProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbClient;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_WPF;component/buyproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BuyProduct.xaml"
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
            
            #line 8 "..\..\BuyProduct.xaml"
            ((Project_WPF.BuyProduct)(target)).Loaded += new System.Windows.RoutedEventHandler(this.FormLoaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\BuyProduct.xaml"
            ((Project_WPF.BuyProduct)(target)).Activated += new System.EventHandler(this.FormActivated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.productlList = ((System.Windows.Controls.ListView)(target));
            
            #line 20 "..\..\BuyProduct.xaml"
            this.productlList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProductSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbProdyctQuntity = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btnAddToBasket = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\BuyProduct.xaml"
            this.btnAddToBasket.Click += new System.Windows.RoutedEventHandler(this.btnAddToBasket_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.basketList = ((System.Windows.Controls.ListView)(target));
            
            #line 37 "..\..\BuyProduct.xaml"
            this.basketList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BasketSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtProductName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtProductNameInBasket = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnDeleteFromBasket = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\BuyProduct.xaml"
            this.btnDeleteFromBasket.Click += new System.Windows.RoutedEventHandler(this.btnDeleteFromBasket_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnConfirmBasket = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\BuyProduct.xaml"
            this.btnConfirmBasket.Click += new System.Windows.RoutedEventHandler(this.btnConfirmBasket_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtSubCategoryName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txtCategoryName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.cbProductQuantityInBasket = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 13:
            this.cbClient = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

