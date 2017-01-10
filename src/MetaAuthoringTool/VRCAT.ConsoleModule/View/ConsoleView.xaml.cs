using System;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace VRCAT.ConsoleModule
{
    /// <summary>
    /// Interaction logic for ConsoleView.xaml
    /// </summary>
    [Export(typeof(ConsoleView))]
    public partial class ConsoleView : UserControl
    {
        public ConsoleView()
        {
            InitializeComponent();
            this.DataContext = new ConsoleViewModel(this);
        }
    }
}
