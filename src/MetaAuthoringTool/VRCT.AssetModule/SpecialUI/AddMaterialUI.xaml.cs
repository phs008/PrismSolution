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
using System.Windows.Shapes;

namespace VRCAT.AssetModule
{
    /// <summary>
    /// [사용안함]
    /// Material 추가 처리 용 UI
    /// </summary>
    public partial class AddMaterialUI : Window
    {
        public AddMaterialUI()
        {
            InitializeComponent();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
