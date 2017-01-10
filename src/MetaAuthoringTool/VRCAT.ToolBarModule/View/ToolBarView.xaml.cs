using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.DataModel;
using VRCAT.Infrastructure;
using VRCAT.DataModel.Event;

namespace VRCAT.ToolBarModule
{
    /// <summary>
    /// Interaction logic for ToolBarView.xaml
    /// </summary>
    [Export(typeof(ToolBarView))]
    public partial class ToolBarView : UserControl
    {
        public ToolBarView()
        {
            InitializeComponent();
            this.DataContext = new ToolBarViewModel();
            /// Render Window 가 생성되고 HierarchyModeule -> HierarchyViewModel 에서 World 를 생성해야지만 Gizmo 처리가 완성된다.
            /// 이후 Gizmo 세팅을 해야지만 nullPtr 이 아님.
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Subscribe(param =>
            {
                if (param.eventArg == EngineEventArg.WorldCreated)
                {
                    Position.ClickMode = ClickMode.Press;
                }
            });
        }
    }
}
