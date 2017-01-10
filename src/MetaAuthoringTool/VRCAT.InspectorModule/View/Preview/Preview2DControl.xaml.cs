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
using VRCAT.DataModel;

namespace VRCAT.InspectorModule
{
    /// <summary>
    /// Preview2DControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Preview2DControl : UserControl 
    {
        public Preview2DControl(FileModel fm)
        {
            InitializeComponent();
            this.DataContext = fm;
        }
    }
}
