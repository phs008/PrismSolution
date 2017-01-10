using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;

namespace VRCAT.WrapperBridge
{
    /// <summary>
    /// LoadingAnimation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadingAnimation : Window
    {
        delegate void HideWindw();
        public LoadingAnimation()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Dispatcher.BeginInvoke(new HideWindw(_HideWindow));
        }

        private void _HideWindow()
        {
            this.Hide();
            (typeof(Window)).GetField("_isClosing", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, false);
            //(typeof(Window)).GetField("_dialogResult", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, private_dialog_result);
            ///private_dialog_result = null;
        }
    }
}
