﻿#pragma checksum "..\..\..\Views\TourView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "322D58F54C3323BE671A62EA5B4C506B229AC93695E7854D8BCF16BD621AF3F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using Tour_Planner_Danny.Views;


namespace Tour_Planner_Danny.Views {
    
    
    /// <summary>
    /// TourView
    /// </summary>
    public partial class TourView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Views\TourView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid backgroundall;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\TourView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Bar;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\Views\TourView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvLog;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\..\Views\TourView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Tourlistview;
        
        #line default
        #line hidden
        
        
        #line 337 "..\..\..\Views\TourView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBarTextBox;
        
        #line default
        #line hidden
        
        
        #line 355 "..\..\..\Views\TourView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMiniMize;
        
        #line default
        #line hidden
        
        
        #line 375 "..\..\..\Views\TourView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonClose;
        
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
            System.Uri resourceLocater = new System.Uri("/Tour_Planner_Danny;component/views/tourview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\TourView.xaml"
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
            this.backgroundall = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Bar = ((System.Windows.Controls.Grid)(target));
            
            #line 42 "..\..\..\Views\TourView.xaml"
            this.Bar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MouseDownPanel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lvLog = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.Tourlistview = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.SearchBarTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 352 "..\..\..\Views\TourView.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MouseDownPanel);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonMiniMize = ((System.Windows.Controls.Button)(target));
            
            #line 355 "..\..\..\Views\TourView.xaml"
            this.ButtonMiniMize.Click += new System.Windows.RoutedEventHandler(this.MinimizeBTn);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 365 "..\..\..\Views\TourView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MaximizeBtn);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonClose = ((System.Windows.Controls.Button)(target));
            
            #line 375 "..\..\..\Views\TourView.xaml"
            this.ButtonClose.Click += new System.Windows.RoutedEventHandler(this.CloseButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
