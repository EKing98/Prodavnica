﻿#pragma checksum "..\..\Prodavnica.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "92B5E4B80F78E4E06C2042E0C1D75ECF9CE40E02839BD21B83795AAC439C7843"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Prodavnice;
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


namespace Prodavnice {
    
    
    /// <summary>
    /// Prodavnica
    /// </summary>
    public partial class Prodavnica : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKudId;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAdresa;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMesto;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNaziv;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodaj;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmeni;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisi;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridKud;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Prodavnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSifra;
        
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
            System.Uri resourceLocater = new System.Uri("/Prodavnica;component/prodavnica.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Prodavnica.xaml"
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
            this.txtKudId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtAdresa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtMesto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnDodaj = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Prodavnica.xaml"
            this.btnDodaj.Click += new System.Windows.RoutedEventHandler(this.BtnDodaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnIzmeni = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Prodavnica.xaml"
            this.btnIzmeni.Click += new System.Windows.RoutedEventHandler(this.BtnIzmeni_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnObrisi = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\Prodavnica.xaml"
            this.btnObrisi.Click += new System.Windows.RoutedEventHandler(this.BtnObrisi_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DataGridKud = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\Prodavnica.xaml"
            this.DataGridKud.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridKud_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtSifra = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

