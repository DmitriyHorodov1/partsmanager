#pragma checksum "..\..\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EDC72CEF4F3437ED50974C0A611E7B10915CCA316DEA1580F996B11FE59CC958"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using manager_parts_0._1;


namespace manager_parts_0._1 {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button agentPage;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button goodsPage;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button emploeesPage;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button suppliesPage;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button salePage;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button customsPage;
        
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
            System.Uri resourceLocater = new System.Uri("/manager_parts_0.1;component/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainPage.xaml"
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
            this.agentPage = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\MainPage.xaml"
            this.agentPage.Click += new System.Windows.RoutedEventHandler(this.agentPage_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.goodsPage = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MainPage.xaml"
            this.goodsPage.Click += new System.Windows.RoutedEventHandler(this.goodsPage_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.emploeesPage = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\MainPage.xaml"
            this.emploeesPage.Click += new System.Windows.RoutedEventHandler(this.emploeesPage_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.suppliesPage = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\MainPage.xaml"
            this.suppliesPage.Click += new System.Windows.RoutedEventHandler(this.suppliesPage_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.salePage = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\MainPage.xaml"
            this.salePage.Click += new System.Windows.RoutedEventHandler(this.salePage_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.customsPage = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\MainPage.xaml"
            this.customsPage.Click += new System.Windows.RoutedEventHandler(this.customsPage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

