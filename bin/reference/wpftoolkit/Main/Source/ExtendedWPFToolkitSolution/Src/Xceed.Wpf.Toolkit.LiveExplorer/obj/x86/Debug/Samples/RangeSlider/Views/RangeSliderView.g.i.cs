﻿#pragma checksum "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5907FD5E855CD83C4F16AF0813143775"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.LiveExplorer;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Xceed.Wpf.Toolkit.LiveExplorer.Samples.RangeSlider.Views {
    
    
    /// <summary>
    /// RangeSliderView
    /// </summary>
    public partial class RangeSliderView : Xceed.Wpf.Toolkit.LiveExplorer.DemoView, System.Windows.Markup.IComponentConnector {
        
        
        #line 588 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lowerRangeStyleComboBox;
        
        #line default
        #line hidden
        
        
        #line 611 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox rangeStyleComboBox;
        
        #line default
        #line hidden
        
        
        #line 635 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox higherRangeStyleComboBox;
        
        #line default
        #line hidden
        
        
        #line 660 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.RangeSlider _rangeSlider;
        
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
            System.Uri resourceLocater = new System.Uri("/Xceed.Wpf.Toolkit.LiveExplorer;component/samples/rangeslider/views/rangeslidervi" +
                    "ew.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.lowerRangeStyleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 593 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
            this.lowerRangeStyleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RangeStyleComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rangeStyleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 617 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
            this.rangeStyleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RangeStyleComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.higherRangeStyleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 641 "..\..\..\..\..\..\Samples\RangeSlider\Views\RangeSliderView.xaml"
            this.higherRangeStyleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RangeStyleComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this._rangeSlider = ((Xceed.Wpf.Toolkit.RangeSlider)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
