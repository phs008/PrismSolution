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
    /// ShowTextureImage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShowTextureImage : Window
    {
        public ShowTextureImage()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                ((VRTextureFilePathVM)this.DataContext).Value = ((FileModel)TextureListBox.SelectedItem).FullPath;
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
