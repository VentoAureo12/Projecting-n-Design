﻿#pragma checksum "..\..\..\Windows\ChangingParamsForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "15ECAA5371A9213A18A20BA2A4026A1E6F67F83995862F4A931E1063FB8B4BA2"
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// ChangingParamsForm
    /// </summary>
    public partial class ChangingParamsForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Windows\ChangingParamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SnapBackButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\ChangingParamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeSportsmenDataButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Windows\ChangingParamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeResultsDataButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\ChangingParamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeTagersDataButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\ChangingParamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeTeamsDataButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/windows/changingparamsform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ChangingParamsForm.xaml"
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
            this.SnapBackButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Windows\ChangingParamsForm.xaml"
            this.SnapBackButton.Click += new System.Windows.RoutedEventHandler(this.SnapBackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ChangeSportsmenDataButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Windows\ChangingParamsForm.xaml"
            this.ChangeSportsmenDataButton.Click += new System.Windows.RoutedEventHandler(this.ChangeSportsmenDataButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ChangeResultsDataButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Windows\ChangingParamsForm.xaml"
            this.ChangeResultsDataButton.Click += new System.Windows.RoutedEventHandler(this.ChangeResultsDataButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChangeTagersDataButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Windows\ChangingParamsForm.xaml"
            this.ChangeTagersDataButton.Click += new System.Windows.RoutedEventHandler(this.ChangeTagersDataButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChangeTeamsDataButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Windows\ChangingParamsForm.xaml"
            this.ChangeTeamsDataButton.Click += new System.Windows.RoutedEventHandler(this.ChangeTeamsDataButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

