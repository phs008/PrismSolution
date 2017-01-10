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

namespace VRCATCompoeser
{
    /// <summary>
    /// AdvanceSetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdvanceSetting : Window
    {
        public AdvanceSetting(MainViewModel dataContext)
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }
        private void PluginListBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(this.PluginListBox);
            var item = GetItemAt(this.PluginListBox, mousePosition);
            if(item != null)
            {
                ((MainViewModel)this.DataContext).SelectedPluginInfo = ((PackageModel)item.DataContext).Description;
            }
        }
        public static ListBoxItem GetItemAt(ListBox listbox , Point clientRelativePosition)
        {
            var HitTestResult = VisualTreeHelper.HitTest(listbox, clientRelativePosition);
            var selectedItem = HitTestResult.VisualHit;
            while(selectedItem != null)
            {
                if (selectedItem is ListBoxItem)
                    break;
                selectedItem = VisualTreeHelper.GetParent(selectedItem);
            }
            return selectedItem != null ? ((ListBoxItem)selectedItem) : null;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
