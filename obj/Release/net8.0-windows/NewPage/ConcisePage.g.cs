﻿#pragma checksum "..\..\..\..\NewPage\ConcisePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2D595093B1A9E44A96A833B14158CC06046555AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Calculator.NewPage;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Calculator.NewPage {
    
    
    /// <summary>
    /// ConcisePage
    /// </summary>
    public partial class ConcisePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainwindow;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Title;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid title;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button maxbutton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closebutton;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button record;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RecordText;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MainText;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border belowdarkpanel;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\NewPage\ConcisePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border sidedarkpanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Calculator;component/newpage/concisepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\NewPage\ConcisePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((Calculator.NewPage.ConcisePage)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Page_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainwindow = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Title = ((System.Windows.Controls.Border)(target));
            
            #line 22 "..\..\..\..\NewPage\ConcisePage.xaml"
            this.Title.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.title = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            
            #line 27 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.sideButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 38 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinimizeButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.maxbutton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\NewPage\ConcisePage.xaml"
            this.maxbutton.Click += new System.Windows.RoutedEventHandler(this.MaximizeButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.closebutton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\NewPage\ConcisePage.xaml"
            this.closebutton.Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.record = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\NewPage\ConcisePage.xaml"
            this.record.Click += new System.Windows.RoutedEventHandler(this.Record_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.RecordText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.MainText = ((System.Windows.Controls.TextBox)(target));
            
            #line 77 "..\..\..\..\NewPage\ConcisePage.xaml"
            this.MainText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.MainText_Change);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 98 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnpercent_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 99 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCE_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 100 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnC_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 101 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnremove_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 102 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.butquarter_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 103 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.butsquare_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 104 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.butradicalsign_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 105 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDiv_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 106 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnMul_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 107 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSub_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 108 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 109 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnbur_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 110 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDot_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 111 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnEqual_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 135 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn1_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 136 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn2_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 137 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn3_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 138 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn4_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 139 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn5_Click);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 140 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn6_Click);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 141 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn7_Click);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 142 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn8_Click);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 143 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn9_Click);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 144 "..\..\..\..\NewPage\ConcisePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn0_Click);
            
            #line default
            #line hidden
            return;
            case 36:
            this.belowdarkpanel = ((System.Windows.Controls.Border)(target));
            
            #line 150 "..\..\..\..\NewPage\ConcisePage.xaml"
            this.belowdarkpanel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BelowDarkPanel_MouseDown);
            
            #line default
            #line hidden
            return;
            case 37:
            this.sidedarkpanel = ((System.Windows.Controls.Border)(target));
            
            #line 156 "..\..\..\..\NewPage\ConcisePage.xaml"
            this.sidedarkpanel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SideDarkPanel_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

