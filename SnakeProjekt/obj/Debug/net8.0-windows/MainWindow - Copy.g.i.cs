﻿#pragma checksum "..\..\..\MainWindow - Copy.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A64121F77947EB602AFA75E5FC26D0ED28E22AEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SnakeProjekt;
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


namespace SnakeProjekt {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextScore;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GameBorder;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid GameGrid;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Overlay;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock HighscoreText;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox HighscoreList;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OverLayText;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartButton;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameInputTextBox;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\MainWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HighscoreButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SnakeProjekt;V1.0.0.0;component/mainwindow%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow - Copy.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\MainWindow - Copy.xaml"
            ((SnakeProjekt.MainWindow)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Window_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\MainWindow - Copy.xaml"
            ((SnakeProjekt.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextScore = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.GameBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.GameGrid = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 5:
            this.Overlay = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.HighscoreText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.HighscoreList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.OverLayText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.StartButton = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\MainWindow - Copy.xaml"
            this.StartButton.Click += new System.Windows.RoutedEventHandler(this.StartButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.NameInputTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.HighscoreButton = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\MainWindow - Copy.xaml"
            this.HighscoreButton.Click += new System.Windows.RoutedEventHandler(this.SaveHighscoreButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

