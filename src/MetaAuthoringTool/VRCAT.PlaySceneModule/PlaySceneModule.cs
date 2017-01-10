using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using VRCAT.Infrastructure.PrismAvalonExtensions;
using VRCAT.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.DataModel;
using System.Collections;
using System.Windows;

namespace VRCAT.PlaySceneModule
{
    /// <summary>
    /// 해당 Assembly 를 DynamicModule 로 구성하기 위한 진입점
    /// </summary>
    [ModuleExport(typeof(PlaySceneModule))]
    public class PlaySceneModule : IModule
    {
        private Stack PlaySceneViewStack = new Stack();
        IRegionManager _regionManager;
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
        }
        /// <summary>
        /// 초기 생성자
        /// </summary>
        /// <remarks>외부에서 ToolBarEvent 를 받아 Game 이벤트 획득시 PalySceneView 를 신규 구성하여 이를 DockingManager 에 추가함</remarks>
        /// <param name="regionManager"></param>
        [ImportingConstructor]
        public PlaySceneModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                if (param.ClickMenuHeader == "Game")
                {
                    if (PlaySceneViewStack.Count == 0)
                    {
                        IRegion r = RegionManager.Regions["DockingRegion"];
                        PlaySceneView rView = new PlaySceneView();
                        PlaySceneViewStack.Push(rView);
                        r.Add(new DockingMetadata(rView, new NestedDockStrategy(rView, NestedDockPosition.Left)) { Title = "Game" });
                    }
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                if (param.ClickMenuHeader == "CloseGame")
                {
                    
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<object>>().Subscribe(param =>
            {
                if(param != null)
                {
                    if(param is PlaySceneView)
                    {
                        PlaySceneView rView = (PlaySceneView)PlaySceneViewStack.Pop();
                        if(rView  == (PlaySceneView)param)
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("ToggleBtnStop"));
                        }
                    }
                }
            });
        }
        /// <summary>
        /// DynamicModule Loading 진입점
        /// </summary>
        public void Initialize()
        { }
    }
}
