using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VRCAT.InspectorModule
{
    /// <summary>
    /// ScriptView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ScriptView : UserControl
    {
        public ScriptView()
        {
            InitializeComponent();
        }

        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                System.Diagnostics.Process.Start("notepad.exe", "/a " + ((TextScriptViewModel)this.DataContext).ScriptFilePath);
            }
        }
    }
}
