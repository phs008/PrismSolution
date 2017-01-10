using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace VRCAT.HierarchyModule
{
    public class MultiSelectTreeView : TreeView
    {
        public MultiSelectTreeView()
        {
            ///GotFocus += OnTreeViewItemGotFocus;
            PreviewMouseRightButtonDown += OnTreeViewItemPreviewMouseDown;
            PreviewMouseRightButtonUp += OnTreeViewItemPreviewMouseUp;
            PreviewMouseLeftButtonDown += OnTreeViewItemPreviewMouseDown;
            PreviewMouseLeftButtonUp += OnTreeViewItemPreviewMouseUp;
        }

        private static TreeViewItem _selectTreeViewItemOnMouseUp;

        public static readonly DependencyProperty IsItemSelectedProperty = DependencyProperty.RegisterAttached("IsItemSelected", typeof(Boolean), typeof(MultiSelectTreeView), new PropertyMetadata(false, OnIsItemSelectedPropertyChanged));

        public static readonly RoutedEvent OnSelectedItemsEvent = EventManager.RegisterRoutedEvent("OnSelectItem", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(MultiSelectTreeView));

        public event RoutedEventHandler OnSelectItem
        {
            add { AddHandler(OnSelectedItemsEvent, value); }
            remove { RemoveHandler(OnSelectedItemsEvent, value); }
        }

        public static readonly RoutedEvent OnSendSelectedItmeToInspectorEvent = EventManager.RegisterRoutedEvent("OnSendSelectedItemToInspector", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(MultiSelectTreeView));

        public event RoutedEventHandler OnSendSelectedItemToInspector
        {
            add { AddHandler(OnSendSelectedItmeToInspectorEvent, value); }
            remove { RemoveHandler(OnSendSelectedItmeToInspectorEvent, value); }
        }


        public static bool GetIsItemSelected(TreeViewItem element)
        {
            return (bool)element.GetValue(IsItemSelectedProperty);
        }

        public static void SetIsItemSelected(TreeViewItem element, Boolean value)
        {
            if (element == null) return;
            element.SetValue(IsItemSelectedProperty, value);
            if(value)
                SetParentItemExpand(element);
        }

        private static void OnIsItemSelectedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeViewItem = d as TreeViewItem;
            var treeView = FindTreeView(treeViewItem);
            if (treeViewItem != null && treeView != null && treeViewItem.Header != null)
            {
                var selectedItems = GetSelectedItems(treeView);
                if (selectedItems != null)
                {
                    if (GetIsItemSelected(treeViewItem))
                    {
                        selectedItems.Add(treeViewItem.Header);
                    }
                    else
                    {
                        selectedItems.Remove(treeViewItem.Header);
                    }
                }
                OnOccureTreeviewSelectedItemChangeEvent(treeView);
            }
        }
        public static void OnOccureTreeviewSelectedItemChangeEvent(TreeView treeView)
        {
            treeView.RaiseEvent(new RoutedEventArgs(OnSelectedItemsEvent));
        }
        public static void OnOccureTreeviewSelectedItemToInspecotEvent(TreeView treeview)
        {
            treeview.RaiseEvent(new RoutedEventArgs(OnSendSelectedItmeToInspectorEvent));
        }

        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.RegisterAttached("SelectedItems", typeof(IList), typeof(MultiSelectTreeView));

        public static IList GetSelectedItems(TreeView element)
        {
            return (IList)element.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(TreeView element, IList value)
        {
            element.SetValue(SelectedItemsProperty, value);
        }

        private static readonly DependencyProperty StartItemProperty = DependencyProperty.RegisterAttached("StartItem", typeof(TreeViewItem), typeof(MultiSelectTreeView));

        private static TreeViewItem GetStartItem(TreeView element)
        {
            return (TreeViewItem)element.GetValue(StartItemProperty);
        }

        private static void SetStartItem(TreeView element, TreeViewItem value)
        {
            element.SetValue(StartItemProperty, value);
        }

        private static readonly DependencyProperty LastItemProperty = DependencyProperty.RegisterAttached("LastItem", typeof(TreeViewItem), typeof(MultiSelectTreeView));
        private static TreeViewItem GetLastItem(TreeView element)
        {
            return (TreeViewItem)element.GetValue(LastItemProperty);
        }
        private static void SetLastItem(TreeView element, TreeViewItem value)
        {
            element.SetValue(LastItemProperty, value);
        }

        private static void SelectItems(TreeViewItem treeViewItem, TreeView treeView)
        {
            if (treeViewItem != null && treeView != null)
            {
                if ((Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
                {
                    SelectMultipleItemsContinuously(treeView, treeViewItem, true);
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    SelectMultipleItemsRandomly(treeView, treeViewItem);
                }
                else if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    SelectMultipleItemsContinuously(treeView, treeViewItem);
                }
                else
                {
                    SelectSingleItem(treeView, treeViewItem);
                }
            }
        }

        private static void OnTreeViewItemGotFocus(object sender, RoutedEventArgs e)
        {
            _selectTreeViewItemOnMouseUp = null;

            if (e.OriginalSource is TreeView) return;

            var treeViewItem = FindTreeViewItem(e.OriginalSource as DependencyObject);
            if (Mouse.LeftButton == MouseButtonState.Pressed && GetIsItemSelected(treeViewItem) && Keyboard.Modifiers != ModifierKeys.Control)
            {
                _selectTreeViewItemOnMouseUp = treeViewItem;
                return;
            }

            SelectItems(treeViewItem, sender as TreeView);
        }

        private static void OnTreeViewItemPreviewMouseDown(object sender, MouseEventArgs e)
        {
            //var treeViewItem = FindTreeViewItem(e.OriginalSource as DependencyObject);

            ///// 마우스 클릭시 TreeViewItem 이 없는 경우 DeSelectAllitem
            //if(treeViewItem == null)
            //{
            //    TreeView treeView = FindTreeView(e.OriginalSource as DependencyObject);
            //    GetSelectedItems(treeView).Clear();
            //    DeSelectAllItems(treeView, null);
            //    return;
            //}

            ////if (treeViewItem != null && treeViewItem.IsFocused)
            ////    OnTreeViewItemGotFocus(sender, e);

            //if (treeViewItem != null)
            //{
            //    _selectTreeViewItemOnMouseUp = null;
            //    if (Mouse.LeftButton == MouseButtonState.Pressed && GetIsItemSelected(treeViewItem) && Keyboard.Modifiers != ModifierKeys.Control)
            //    {
            //        _selectTreeViewItemOnMouseUp = treeViewItem;
            //        return;
            //    }
            //    SelectItems(treeViewItem, sender as TreeView);
            //}
            //OnTreeViewItemGotFocus(sender, e);


            ///////////////// Preview Mouse up code

            var treeViewItem = FindTreeViewItem(e.OriginalSource as DependencyObject);

            /// 마우스 클릭시 TreeViewItem 이 없는 경우 DeSelectAllitem
            if (treeViewItem == null)
            {
                TreeView treeView = FindTreeView(e.OriginalSource as DependencyObject);
                GetSelectedItems(treeView).Clear();
                DeSelectAllItems(treeView, null);
                OnOccureTreeviewSelectedItemChangeEvent(treeView);
                return;
            }

            //if (treeViewItem != null && treeViewItem.IsFocused)
            //    OnTreeViewItemGotFocus(sender, e);

            if (treeViewItem != null)
            {
                _selectTreeViewItemOnMouseUp = null;
                if (Mouse.LeftButton == MouseButtonState.Pressed && GetIsItemSelected(treeViewItem) && Keyboard.Modifiers != ModifierKeys.Control)
                {
                    _selectTreeViewItemOnMouseUp = treeViewItem;
                    return;
                }
                SelectItems(treeViewItem, sender as TreeView);
            }

            /// Occured the Selected Item Change Event when Mouse up
            TreeView tView = FindTreeView(e.OriginalSource as DependencyObject);
            if (tView != null)
                OnOccureTreeviewSelectedItemChangeEvent(tView);


            //var treeViewItem = FindTreeViewItem(e.OriginalSource as DependencyObject);

            //if (treeViewItem == _selectTreeViewItemOnMouseUp)
            //{
            //    SelectItems(treeViewItem, sender as TreeView);
            //}


            //treeView.RaiseEvent(new RoutedEventArgs(OnSelectedItemsEvent));
        }

        private static void OnTreeViewItemPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //var treeViewItem = FindTreeViewItem(e.OriginalSource as DependencyObject);

            ///// 마우스 클릭시 TreeViewItem 이 없는 경우 DeSelectAllitem
            //if (treeViewItem == null)
            //{
            //    TreeView treeView = FindTreeView(e.OriginalSource as DependencyObject);
            //    GetSelectedItems(treeView).Clear();
            //    DeSelectAllItems(treeView, null);
            //    return;
            //}

            ////if (treeViewItem != null && treeViewItem.IsFocused)
            ////    OnTreeViewItemGotFocus(sender, e);

            //if (treeViewItem != null)
            //{
            //    _selectTreeViewItemOnMouseUp = null;
            //    if (Mouse.LeftButton == MouseButtonState.Pressed && GetIsItemSelected(treeViewItem) && Keyboard.Modifiers != ModifierKeys.Control)
            //    {
            //        _selectTreeViewItemOnMouseUp = treeViewItem;
            //        return;
            //    }
            //    SelectItems(treeViewItem, sender as TreeView);
            //}




            ////var treeViewItem = FindTreeViewItem(e.OriginalSource as DependencyObject);

            ////if (treeViewItem == _selectTreeViewItemOnMouseUp)
            ////{
            ////    SelectItems(treeViewItem, sender as TreeView);
            ////}

            ///// Occured the Selected Item Change Event when Mouse up
            //TreeView tView = FindTreeView(e.OriginalSource as DependencyObject);
            //if (tView != null)
            //    OnOccureTreeviewSelectedItemChangeEvent(tView);
            ////treeView.RaiseEvent(new RoutedEventArgs(OnSelectedItemsEvent));


            TreeView tView = FindTreeView(e.OriginalSource as DependencyObject);
            if (tView != null)
                OnOccureTreeviewSelectedItemToInspecotEvent(tView);
        }

        private static TreeViewItem FindTreeViewItem(DependencyObject dependencyObject)
        {
            if (!(dependencyObject is Visual || dependencyObject is Visual3D))
                return null;

            var treeViewItem = dependencyObject as TreeViewItem;
            if (treeViewItem != null)
            {
                return treeViewItem;
            }

            return FindTreeViewItem(VisualTreeHelper.GetParent(dependencyObject));
        }

        private static void SelectSingleItem(TreeView treeView, TreeViewItem treeViewItem)
        {
            // first deselect all items
            DeSelectAllItems(treeView, null);
            var selectedItems = GetSelectedItems(treeView);
            selectedItems.Clear();
            SetIsItemSelected(treeViewItem, true);
            SetStartItem(treeView, treeViewItem);
            SetLastItem(treeView, treeViewItem);
        }

        private static void DeSelectAllItems(TreeView treeView, TreeViewItem treeViewItem)
        {
            if (treeView != null)
            {
                for (int i = 0; i < treeView.Items.Count; i++)
                {
                    var item = treeView.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                    if (item != null)
                    {
                        SetIsItemSelected(item, false);
                        DeSelectAllItems(null, item);
                    }
                }
            }
            else
            {
                for (int i = 0; i < treeViewItem.Items.Count; i++)
                {
                    var item = treeViewItem.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                    if (item != null)
                    {
                        SetIsItemSelected(item, false);
                        DeSelectAllItems(null, item);
                    }
                }
            }
        }

        private static TreeView FindTreeView(DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
            {
                return null;
            }

            var treeView = dependencyObject as TreeView;

            return treeView ?? FindTreeView(VisualTreeHelper.GetParent(dependencyObject));
        }

        internal static void SelectMultipleItemsRandomly(TreeView treeView, TreeViewItem treeViewItem)
        {
            SetIsItemSelected(treeViewItem, !GetIsItemSelected(treeViewItem));
            if (GetStartItem(treeView) == null || Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (GetIsItemSelected(treeViewItem))
                {
                    SetStartItem(treeView, treeViewItem);
                }
            }
            else
            {
                if (GetSelectedItems(treeView).Count == 0)
                {
                    SetStartItem(treeView, null);
                }
            }
        }

        private static void SelectMultipleItemsContinuously(TreeView treeView, TreeViewItem treeViewItem, bool shiftControl = false)
        {
            TreeViewItem startItem = GetStartItem(treeView);
            if (startItem != null)
            {
                if (startItem == treeViewItem)
                {
                    SelectSingleItem(treeView, treeViewItem);
                    return;
                }

                ICollection<TreeViewItem> allItems = new List<TreeViewItem>();
                GetAllItems(treeView, null, allItems);
                //DeSelectAllItems(treeView, null);
                bool isBetween = false;
                foreach (var item in allItems)
                {
                    if (item == treeViewItem || item == startItem)
                    {
                        // toggle to true if first element is found and
                        // back to false if last element is found
                        isBetween = !isBetween;

                        // set boundary element
                        SetIsItemSelected(item, true);
                        continue;
                    }

                    if (isBetween)
                    {
                        SetIsItemSelected(item, true);
                        continue;
                    }

                    if (!shiftControl)
                        SetIsItemSelected(item, false);
                }
            }
        }

        private static void GetAllItems(TreeView treeView, TreeViewItem treeViewItem, ICollection<TreeViewItem> allItems)
        {
            if (treeView != null)
            {
                for (int i = 0; i < treeView.Items.Count; i++)
                {
                    var item = treeView.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                    if (item != null)
                    {
                        allItems.Add(item);
                        GetAllItems(null, item, allItems);
                    }
                }
            }
            else
            {
                for (int i = 0; i < treeViewItem.Items.Count; i++)
                {
                    var item = treeViewItem.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                    if (item != null)
                    {
                        allItems.Add(item);
                        GetAllItems(null, item, allItems);
                    }
                }
            }
        }
        //protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        //{
        //    base.PrepareContainerForItemOverride(element, item);
        //}
        /// <summary>
        /// 선택된 객체가 하위 객체일 경우 상위 객체 TreeviewItem 에 대해 Expand 를 적용하여 화면상에서 펼쳐지게 처리 하는것.
        /// TOO : 테스트 미흡 (이유 : 3D 공간상에서 객체 선택시 상위 객체가 선택되게 되어있음)
        /// </summary>
        /// <param name="item"></param>
        private static void SetParentItemExpand(TreeViewItem item)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(item);
            while (!(parent is TreeViewItem || parent is TreeViewItem) && parent != null)
            {
                parent = VisualTreeHelper.GetParent(parent);
                if (parent is MultiSelectTreeView)
                    parent = null;
            }
            if (parent != null)
                ((TreeViewItem)parent).IsExpanded = true;
        }
    }
}
