using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VRCAT.Infrastructure
{
    public enum SelectionModalities
    {
        SingleSelectionOnly,
        MultipleSelectionOnly,
        KeyboardModifiersMode
    }

    public class SelectedItemsCollection : ObservableCollection<MultipleSelectionTreeViewItem> { }

    public class MultiSelectTreeView : ItemsControl
    {
        #region Properties
        private MultipleSelectionTreeViewItem _lastClickedItem = null;

        public SelectionModalities SelectionMode
        {
            get { return (SelectionModalities)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(SelectionModalities), typeof(MultiSelectTreeView), new UIPropertyMetadata(SelectionModalities.SingleSelectionOnly));

        //private SelectedItemsCollection _selectedItems = new SelectedItemsCollection();
        //public SelectedItemsCollection SelectedItems
        //{
        //    get { return _selectedItems; }
        //}
        public SelectedItemsCollection SelectedItems
        {
            get { return (SelectedItemsCollection)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(SelectedItemsCollection), typeof(MultiSelectTreeView), new UIPropertyMetadata(new SelectedItemsCollection()));

        public MultipleSelectionTreeViewItem LastClickedItem
        {
            get { return (MultipleSelectionTreeViewItem)GetValue(LastClickItemProperty); }
            set { SetValue(LastClickItemProperty, value); }
        }
        public static readonly DependencyProperty LastClickItemProperty =
            DependencyProperty.Register("LastClickedItem", typeof(MultipleSelectionTreeViewItem), typeof(MultiSelectTreeView));

        #endregion

        #region Constructors
        static MultiSelectTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                    typeof(MultiSelectTreeView), new FrameworkPropertyMetadata(typeof(MultiSelectTreeView)));
        }
        #endregion

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MultipleSelectionTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is MultipleSelectionTreeViewItem;
        }

        internal void OnSelectionChanges(MultipleSelectionTreeViewItem viewItem)
        {
            MultipleSelectionTreeViewItem newItem = viewItem;
            if (newItem == null)
                return;

            bool isNewItemMultipleSelected = viewItem.IsSelected;

            if (isNewItemMultipleSelected)
                AddItemToSelection(viewItem);
            else
                RemoveItemFromSelection(viewItem);
        }

        internal void OnViewItemMouseDown(MultipleSelectionTreeViewItem viewItem)
        {
            MultipleSelectionTreeViewItem newItem = viewItem;
            if (newItem == null)
                return;

            switch (this.SelectionMode)
            {
                case SelectionModalities.MultipleSelectionOnly:
                    ManageCtrlSelection(newItem);
                    break;
                case SelectionModalities.SingleSelectionOnly:
                    ManageSingleSelection(newItem);
                    break;
                case SelectionModalities.KeyboardModifiersMode:
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                    {
                        // ... TODO ... right now we use the same behavior of Shit Keyword
                        ManageCtrlSelection(newItem);
                        //ManageShiftSelection(viewItem);
                    }
                    else if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        ManageCtrlSelection(newItem);
                    }
                    else
                    {
                        ManageSingleSelection(newItem);
                    }
                    break;
            }

            LastClickedItem = viewItem.IsSelected ? viewItem : null;
        }

        #region Methods
        public void UnselectAll()
        {
            if (Items != null && Items.Count > 0)
            {
                foreach (var item in Items)
                {
                    if (item is MultipleSelectionTreeViewItem)
                    {
                        ((MultipleSelectionTreeViewItem)item).UnselectAllChildren();
                    }
                    else
                    {
                        MultipleSelectionTreeViewItem tvItem = this.ItemContainerGenerator.ContainerFromItem(item) as MultipleSelectionTreeViewItem;

                        if (tvItem != null)
                            tvItem.UnselectAllChildren();
                    }
                }
            }
        }

        public void SelectAllExpandedItems()
        {
            if (Items != null && Items.Count > 0)
            {
                foreach (var item in Items)
                {
                    if (item is MultipleSelectionTreeViewItem)
                    {
                        ((MultipleSelectionTreeViewItem)item).SelectAllExpandedChildren();
                    }
                    else
                    {
                        MultipleSelectionTreeViewItem tvItem = this.ItemContainerGenerator.ContainerFromItem(item) as MultipleSelectionTreeViewItem;

                        if (tvItem != null)
                            tvItem.SelectAllExpandedChildren();
                    }
                }
            }
        }
        #endregion

        #region Helper Methods
        private void AddItemToSelection(MultipleSelectionTreeViewItem newItem)
        {
            if (!SelectedItems.Contains(newItem))
                SelectedItems.Add(newItem);
            //if (!_selectedItems.Contains(newItem))
            //    _selectedItems.Add(newItem);
        }

        private void RemoveItemFromSelection(MultipleSelectionTreeViewItem newItem)
        {
            if (!SelectedItems.Contains(newItem))
                SelectedItems.Remove(newItem);
            //if (_selectedItems.Contains(newItem))
            //    _selectedItems.Remove(newItem);
        }

        private void ManageCtrlSelection(MultipleSelectionTreeViewItem viewItem)
        {
            bool isViewItemMultipleSelected = viewItem.IsSelected;

            if (isViewItemMultipleSelected)
                AddItemToSelection(viewItem);
            else if (!isViewItemMultipleSelected)
                RemoveItemFromSelection(viewItem);
        }

        private void ManageSingleSelection(MultipleSelectionTreeViewItem viewItem)
        {
            bool isViewItemMultipleSelected = viewItem.IsSelected;

            UnselectAll();

            if (isViewItemMultipleSelected)
            {
                viewItem.IsSelected = isViewItemMultipleSelected;
                AddItemToSelection(viewItem);
            }
        }

        /// <summary>
        /// ... TODO ...
        /// </summary>
        /// <param name="viewItem"></param>
        private void ManageShiftSelection(MultipleSelectionTreeViewItem viewItem)
        {
            bool isViewItemMultipleSelected = viewItem.IsSelected;

            if (LastClickedItem != null)
            {
                // BEGIN TODO
                IsItem1ListedBeforeItem2(LastClickedItem, viewItem);
                // END TODO
            }

            if (isViewItemMultipleSelected)
            {
                viewItem.SelectAllExpandedChildren();
                //viewItem.IsExpanded = true; // TO BE CLARIFY: this expand only item children, does not expand children of children
                AddItemToSelection(viewItem);
            }
            else
            {
                viewItem.UnselectAllChildren();
            }
        }

        /// <summary>
        /// ... TODO ...
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        private bool IsItem1ListedBeforeItem2(MultipleSelectionTreeViewItem item1,
                                              MultipleSelectionTreeViewItem item2)
        {
            /*
            // Perform a Backword search (up)
            if (item1.ParentMultipleSelectionTreeViewItem != null) // item1 has a brother!
            {
                ItemCollection brothers = item1.ParentMultipleSelectionTreeViewItem.Items;
                int indexOfItem1 = brothers.IndexOf(item1);
                int indexOfItem2 = brothers.IndexOf(item2);
                if (indexOfItem2 >= 0) //item1 and item2 are brothers
                {
                    return indexOfItem1 < indexOfItem2 ? true : false;
                }

                
            }
            */

            return true;
        }

        /// <summary>
        /// ... TODO ...
        /// </summary>
        /// <param name="fromItem"></param>
        /// <param name="toItem"></param>
        private void SelectRange(MultipleSelectionTreeViewItem fromItem,
                                 MultipleSelectionTreeViewItem toItem)
        {
        }
        #endregion

    }
}
