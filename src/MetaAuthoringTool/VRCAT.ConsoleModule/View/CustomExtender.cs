using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VRCAT.ConsoleModule
{
    public class CustomButton : Button
    {
        private bool _IsClicked = false;
        public bool IsClicked
        {
            get { return _IsClicked; }
            set { _IsClicked = value; }
        }
    }

    #region 사용되지 않음
    /// <summary>
    /// DependencyProperty 를 추가하고 이를 통해 AutoScroll 처리 해주는 DependencyObject
    /// </summary>
    public class UIExtenders : DependencyObject
    {
        public static readonly DependencyProperty AutoScrollToEndProperty = DependencyProperty.RegisterAttached("AutoScrollToEnd", typeof(bool), typeof(ListBox),
            new UIPropertyMetadata(default(bool), OnAutoScrollToEndChanged));

        public static bool GetAutoScrollToEnd(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToEndProperty);
        }
        public static void SetAutoScrollToEnd(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToEndProperty, value);
        }

        private static void OnAutoScrollToEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listBox = d as ListBox;
            var listBoxItems = listBox.Items;
            var data = listBoxItems.SourceCollection as INotifyCollectionChanged;
            var scrollToEndHandle = new NotifyCollectionChangedEventHandler((s1, e1) =>
            {
                if (listBox.Items.Count > 0)
                {
                    object lastItem = listBox.Items[listBox.Items.Count - 1];
                    listBoxItems.MoveCurrentTo(lastItem);
                    listBox.ScrollIntoView(lastItem);
                }
            });
            if ((bool)e.NewValue)
                data.CollectionChanged += scrollToEndHandle;
            else
                data.CollectionChanged -= scrollToEndHandle;
        }
    }
    #endregion
}
