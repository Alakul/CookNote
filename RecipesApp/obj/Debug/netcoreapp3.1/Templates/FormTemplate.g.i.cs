﻿#pragma checksum "..\..\..\..\Templates\FormTemplate.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4A3892C77FADE421841AFD631D17DB924E6071C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using RecipesApp.ValidationRules;
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


namespace RecipesApp.Templates {
    
    
    /// <summary>
    /// FormTemplate
    /// </summary>
    public partial class FormTemplate : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollViewer;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox title;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox description;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox category;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock file;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ingredients;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox method;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\Templates\FormTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button actionButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RecipesApp;component/templates/formtemplate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Templates\FormTemplate.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.scrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 2:
            this.title = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.category = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 69 "..\..\..\..\Templates\FormTemplate.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SelectFileButton);
            
            #line default
            #line hidden
            return;
            case 6:
            this.file = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 73 "..\..\..\..\Templates\FormTemplate.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteFileButton);
            
            #line default
            #line hidden
            return;
            case 8:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.ingredients = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.method = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.actionButton = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\..\Templates\FormTemplate.xaml"
            this.actionButton.Click += new System.Windows.RoutedEventHandler(this.RecipeAction);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

