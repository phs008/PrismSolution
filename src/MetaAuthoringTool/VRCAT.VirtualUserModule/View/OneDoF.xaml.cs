using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System.Windows;
using System.Windows.Media;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;

namespace VRCAT.VirtualUserModule
{
    /// <summary>
    /// OneDoF.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OneDoF : Window , IDropTarget
    {
        MContainer _engageObject;
        float _savedX;
        float _savedY;
        float _savedZ;
        public OneDoF()
        {
            InitializeComponent();
            this.Loaded += OneDoF_Loaded;
            this.Closing += OneDoF_Closing;
        }

        private void OneDoF_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Hidden;
        }

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataModel.NodeVM)
                dropInfo.Effects = DragDropEffects.Copy;
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataModel.NodeVM)
            {
                this._engageObject = (MContainer)((DataModel.NodeVM)dropInfo.Data).NodeObject;
                this._savedX = _engageObject.Transform.Rotation.X;
                this._savedY = _engageObject.Transform.Rotation.Y;
                this._savedZ = _engageObject.Transform.Rotation.Z;
                this._engageObjectText.Text = this._engageObject.Name;
                this._engageObjectText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
        }

        private void OneDoF_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void scrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_engageObject != null)
            {
                double value = e.NewValue;
                this._engageObject.Transform.Rotation.Y = (float)value;
                MWorld.GetInstance().FrameAnimate();
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("InspectorUpdateEvent");
            }
        }

        private void UnengageButton_Click(object sender, RoutedEventArgs e)
        {
            if (this._engageObject != null)
            {
                this._engageObject.Transform.Rotation.X = this._savedX;
                this._engageObject.Transform.Rotation.Y = this._savedY;
                this._engageObject.Transform.Rotation.Z = this._savedZ;
                this._engageObject = null;
                this._engageObjectText.Text = "연결된 오브젝트가 없습니다.";
                this._engageObjectText.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("EngineRefresh");
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<GizmoChangeEvent>>().Publish(new GizmoChangeEvent());


            }
        }
    }
}
