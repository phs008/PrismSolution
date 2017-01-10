using MVRWrapper;
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

namespace VRCAT.InspectorModule
{
    /// <summary>
    /// PropertyView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export(typeof(InspectorView))]
    public partial class InspectorView : UserControl
    {
        InspectorViewModel vm;
        public InspectorView()
        {
            InitializeComponent();
            Loaded += PropertyView_Loaded;
        }

        void PropertyView_Loaded(object sender, RoutedEventArgs e)
        {
            vm = new InspectorViewModel();
            this.DataContext = vm;
            foreach(string componentName in MRuntimeComponent.GetInstance().ComponentList)
            {
                MenuItem item = new MenuItem();
                item.Header = componentName;
                item.Command = vm.AddComponentCommand;
                item.CommandParameter = componentName;
                this.AddComponentContextMenu.Items.Add(item);
            }
        }

        private void GridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (e.VerticalChange < 0)
            {
                if (this.previewRowDefinition.Height.Value < 150)
                    this.previewRowDefinition.Height = new GridLength(150);
            }
            else if (e.VerticalChange > 0)
            {
                if (this.previewRowDefinition.Height.Value < 150)
                    this.previewRowDefinition.Height = new GridLength(0);
            }
        }

        private void AddComponent_Click(object sender, RoutedEventArgs e)
        {
            Button myBtn = (sender as Button);
            myBtn.ContextMenu.IsEnabled = true;
            myBtn.ContextMenu.PlacementTarget = (sender as Button);
            myBtn.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            myBtn.ContextMenu.IsOpen = true;
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
