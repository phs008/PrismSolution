using Microsoft.Practices.Prism.PubSubEvents;
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
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using MVRWrapper;
using System.Collections.ObjectModel;

namespace VRCAT.HierarchyModule
{
    /// <summary>
    /// HierarchyView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export(typeof(HierarchyView))]
    public partial class HierarchyView : UserControl
    {
        HierarchyViewVM vm = new HierarchyViewVM();
        public HierarchyView()
        {
            InitializeComponent();
            this.DataContext = vm;
            Loaded += HierarchyView_Loaded;
        }

        private void HierarchyView_Loaded(object sender, RoutedEventArgs e)
        {
            /// 피킹 메세지 들어왔을때
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<PickingEvent>>().Subscribe(param =>
            {
                if(VRWorld.Instance.LasetedSelectedContainer != null)
                {
                    HierarchyVM selectItem = GetDataContextInItemCollection(((MContainer)VRWorld.Instance.LasetedSelectedContainer).UID, this.SceneObjectTree.Items);
                    if (selectItem != null)
                    {
                        TreeViewItem item = FindViewContainerObjectRecursive(this.SceneObjectTree, selectItem);
                        if (item != null)
                        {
                            item.IsSelected = true;
                            SelectCustomItem = (NodeVM)selectItem;
                            ((HierarchyViewVM)this.DataContext).BeforeSelectedObj = (MContainer)selectItem.NodeObject;
                            //((HierarchyViewVM)this.DataContext).TreeNodeItemClick(selectItem.NodeObject);
                        }
                    }
                }
                else
                {
                    ResetSelect(this.SceneObjectTree);
                    ((HierarchyViewVM)this.DataContext).TreeNodeItemClick(null);
                }
            });
        }

        public static readonly DependencyProperty SelectCustomItemProperty = DependencyProperty.Register("SelectCustomItem", typeof(object), typeof(HierarchyView));
        public object SelectCustomItem
        {
            get { return (object)GetValue(SelectCustomItemProperty); }
            set { SetValue(SelectCustomItemProperty, value); }
        }

        private void SceneObjectTree_PreviewMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
            if (treeViewItem != null)
            {
                if (treeViewItem.Header is NodeVM)
                {
                    SelectCustomItem = ((NodeVM)treeViewItem.Header).NodeObject;
                    //((HierarchyVM)treeViewItem.Header).IsExpanded = true;
                    //((HierarchyVM)treeViewItem.Header).IsSelected = true;
                }
            }
            else
            {
                SelectCustomItem = null;
                ResetSelect(this.SceneObjectTree);
            }
        }

        /// <summary>
        /// WPF Visual Object Source 기반으로 상위로 TreeViewItem 을 찾아가는 함수
        /// </summary>
        /// <param name="source">WPF Visual Object Source</param>
        /// <returns></returns>
        private TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        /// <summary>
        /// TreeView Items 에서 DataContext 를 가져온다.
        /// </summary>
        /// <param name="comparePointAddress">포인터 주소</param>
        /// <param name="ParentCol"></param>
        /// <returns></returns>
        private HierarchyVM GetDataContextInItemCollection(long compareUID, ItemCollection ParentCol)
        {
            HierarchyVM returnVal = null;
            foreach (HierarchyVM childItem in ParentCol)
            {
                if (compareUID == ((MContainer)childItem.NodeObject).UID)
                {
                    returnVal = childItem;
                    break;
                }
                if (childItem.ChildObject.Count > 0)
                    returnVal = GetDataContextInObservableCollection(compareUID, childItem.ChildObject);
            }
            return returnVal;
        }

        /// <summary>
        /// DataContext 의 하위 DataCollection 에서 DataContext 를 가져온다.
        /// </summary>
        /// <param name="comparePointAddress">포인터 주소</param>
        /// <param name="ParentCol"></param>
        /// <returns></returns>
        private HierarchyVM GetDataContextInObservableCollection(long compareUID, ObservableCollection<NodeVM> ParentCol)
        {
            HierarchyVM returnVal = null;
            foreach (HierarchyVM childItem in ParentCol)
            {
                if (compareUID == ((MContainer)childItem.NodeObject).UID)
                {
                    returnVal = childItem;
                    break;
                }
                if (childItem.ChildObject.Count > 0)
                    returnVal = GetDataContextInObservableCollection(compareUID, childItem.ChildObject);
            }
            return returnVal;
        }

        /// <summary>
        /// Object(DataContet) 로 비교해 ItemControl 에서 해당 VisualObject(TreeViewItem) 을 가져온다.
        /// </summary>
        /// <param name="ic"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        private TreeViewItem FindViewContainerObjectRecursive(ItemsControl ic, object o)
        {
            if (ic != null)
            {
                //Search for the object model in first level children (recursively)
                TreeViewItem tvi = ic.ItemContainerGenerator.ContainerFromItem(o) as TreeViewItem;
                if (tvi != null) return tvi;
                //Loop through user object models
                foreach (object i in ic.Items)
                {
                    //Get the TreeViewItem associated with the iterated object model
                    TreeViewItem tvi2 = ic.ItemContainerGenerator.ContainerFromItem(i) as TreeViewItem;
                    tvi = FindViewContainerObjectRecursive(tvi2, o);
                    if (tvi != null) return tvi;
                }
                return null;
            }
            else
                return null;
        }
        
        /// <summary>
        /// TreeView 에서 IsSelected를 모두 Disable 처리
        /// </summary>
        private void ResetSelect(ItemsControl ic)
        {
            for (int i = 0; i < ic.Items.Count; i++)
            {
                TreeViewItem tvi = ic.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                if (tvi != null)
                {
                    tvi.IsSelected = false;
                    if (tvi.Items.Count > 0)
                        ResetSelect(tvi);
                }
            }
        }

    }
}
