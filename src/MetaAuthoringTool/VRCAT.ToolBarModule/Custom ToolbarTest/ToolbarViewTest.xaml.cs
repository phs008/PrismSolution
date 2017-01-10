using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace VRCAT.ToolBarModule
{
    /// <summary>
    /// ToolbarViewTest.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export(typeof(ToolbarViewTest))]
    public partial class ToolbarViewTest : UserControl
    {
        public ToolbarViewTest()
        {
            InitializeComponent();
            this.DataContext = new ToolBarViewModelTest();
        }
        private void Position_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ToolBarViewModelTest).PositionClick();
        }

        private void Rotation_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ToolBarViewModelTest).RotationClick();
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ToolBarViewModelTest).ScalClick();
        }
    }
}
