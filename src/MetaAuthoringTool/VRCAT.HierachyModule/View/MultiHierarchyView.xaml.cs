using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
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
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;

namespace VRCAT.HierarchyModule
{
    /// <summary>
    /// MultiHierarchyView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MultiHierarchyView : UserControl
    {
        MultiHierarchyViewVM vm = new MultiHierarchyViewVM();
        public MultiHierarchyView()
        {
            InitializeComponent();
            this.DataContext = vm;
            Loaded += MultiHierarchyView_Loaded;
            this.GotFocus += MultiHierarchyView_GotFocus;
            this.LostFocus += MultiHierarchyView_LostFocus;
        }

        private void MultiHierarchyView_LostFocus(object sender, RoutedEventArgs e)
        {
            ((MultiHierarchyViewVM)this.DataContext).IsFocused = false;
        }

        private void MultiHierarchyView_GotFocus(object sender, RoutedEventArgs e)
        {
            ((MultiHierarchyViewVM)this.DataContext).IsFocused = true;
        }

        private void MultiHierarchyView_Loaded(object sender, RoutedEventArgs e)
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Subscribe(param =>
            {
                UnSelect(this.MultiSelectTreeView);
                MultiSelectTreeView.GetSelectedItems(this.MultiSelectTreeView).Clear();
                foreach (object o in param.PickElements)
                {
                    SelectItem(this.MultiSelectTreeView, ((MContainer)o).UID);
                }
                MultiSelectTreeView.OnOccureTreeviewSelectedItemChangeEvent(this.MultiSelectTreeView);
                MultiSelectTreeView.OnOccureTreeviewSelectedItemToInspecotEvent(this.MultiSelectTreeView);
            });
        }

        private void UnSelect(ItemsControl ic)
        {
            for (int i = 0; i < ic.Items.Count; i++)
            {
                TreeViewItem tvi = ic.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                if (tvi != null)
                {
                    tvi.IsSelected = false;
                    MultiSelectTreeView.SetIsItemSelected(tvi, false);
                    if (tvi.Items.Count > 0)
                        UnSelect(tvi);
                }
            }
        }
        private void SelectItem(ItemsControl ic,long compareUID)
        {
            ic.UpdateLayout();
            for (int i = 0; i < ic.Items.Count; i++)
            {
                TreeViewItem tvi = ic.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                if (tvi != null)
                {
                    long uid = ((MContainer)((HierarchyVM)tvi.Header).NodeObject).UID;
                    if (uid == compareUID)
                    {
                        MultiSelectTreeView.SetIsItemSelected(tvi, true);
                        break;
                    }
                    if (tvi.Items.Count > 0)
                        SelectItem(tvi, compareUID);
                }
            }
        }
    }
}
