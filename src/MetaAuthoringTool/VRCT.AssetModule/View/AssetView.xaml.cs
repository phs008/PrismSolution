using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VRCAT.AssetModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [Export(typeof(AssetView))]
    public partial class AssetView : UserControl
    {
        bool IsFirstLoad = true;
        AssetViewModel viewmodel;
        public AssetView()
        {
            InitializeComponent();
            this.DataContext = new AssetViewModel();
            this.GotFocus += AssetView_GotFocus;
            this.LostFocus += AssetView_LostFocus;
        }

        private void AssetView_LostFocus(object sender, RoutedEventArgs e)
        {
            ((AssetViewModel)this.DataContext).IsFocused = false;
        }

        private void AssetView_GotFocus(object sender, RoutedEventArgs e)
        {
            ((AssetViewModel)this.DataContext).IsFocused = true;
        }

        public static readonly DependencyProperty SelectCustomItemProperty = DependencyProperty.Register("SelectCustomItem", typeof(object), typeof(AssetView));
        public object SelectCustomItem
        {
            get { return (object)GetValue(SelectCustomItemProperty); }
            set { SetValue(SelectCustomItemProperty, value); }
        }
        private void AssetTreeView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject);
            if(treeViewItem != null)
            {
                treeViewItem.Focus();
            }
        }
        static T VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && !(source is T))
                source = VisualTreeHelper.GetParent(source);

            return (T)Convert.ChangeType(source, typeof(T));
        }

        private void viewOption_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.IsLoaded == false)
            {
                e.Handled = true;
                return;
            }
            if(0 == e.NewValue)
            {
                this.AssetListBox.ItemTemplate = this.Resources["detailViewTemplate"] as DataTemplate;
                this.AssetListBox.ItemsPanel = this.Resources["detailViewPaenelTemplate"] as ItemsPanelTemplate;
            }
            else if(1 == e.NewValue)
            {
                this.AssetListBox.ItemTemplate = this.Resources["smallViewTemplate"] as DataTemplate;
                this.AssetListBox.ItemsPanel = this.Resources["commonViewPanelTemplate"] as ItemsPanelTemplate;
            }
            else if (2 == e.NewValue)
            {
                this.AssetListBox.ItemTemplate = this.Resources["mediumViewTemplate"] as DataTemplate;
                this.AssetListBox.ItemsPanel = this.Resources["commonViewPanelTemplate"] as ItemsPanelTemplate;
            }
            else if (3 == e.NewValue)
            {
                this.AssetListBox.ItemTemplate = this.Resources["largeViewTemplate"] as DataTemplate;
                this.AssetListBox.ItemsPanel = this.Resources["commonViewPanelTemplate"] as ItemsPanelTemplate;
            }
        }

        private void AssetListBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem listboxItem = VisualUpwardSearch<ListBoxItem>(e.OriginalSource as DependencyObject);
            if (listboxItem != null)
                SelectCustomItem = listboxItem.Content;
            else
                SelectCustomItem = null;
        }
    }
}
