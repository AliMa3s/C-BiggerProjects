#pragma checksum "..\..\..\Straatwpf.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92A4C34038105CF8DD337E70F33FC87915221FC2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfAdresBheerv1;


namespace WpfAdresBheerv1 {
    
    
    /// <summary>
    /// Straatwpf
    /// </summary>
    public partial class Straatwpf : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox niscode_txt;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox straat_txt;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Update;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Verwijderstraat;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Insert;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Straatwpf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox id_txt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfAdresBheerv1;V1.0.0.0;component/straatwpf.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Straatwpf.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.niscode_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.straat_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.datagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Straatwpf.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 16 "..\..\..\Straatwpf.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Terug);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_Update = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Straatwpf.xaml"
            this.btn_Update.Click += new System.Windows.RoutedEventHandler(this.Btn_Update_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Verwijderstraat = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Straatwpf.xaml"
            this.btn_Verwijderstraat.Click += new System.Windows.RoutedEventHandler(this.Btn_VerwijderStraat_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Insert = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Straatwpf.xaml"
            this.btn_Insert.Click += new System.Windows.RoutedEventHandler(this.Btn_Insert_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.id_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

