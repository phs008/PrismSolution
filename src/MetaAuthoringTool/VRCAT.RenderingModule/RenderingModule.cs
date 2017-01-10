using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using VRCAT.Infrastructure.PrismAvalonExtensions;
using VRCAT.Infrastructure;
using VRCAT.DataModel;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.Generic;

namespace VRCAT.RenderingModule
{
    /// <summary>
    /// 해당 Assembly 를 DynamicModule 로 구성하기 위한 진입점
    /// </summary>
    [ModuleExport(typeof(RenderingModule))]
    public class RenderingModule : IModule
    {
        IRegionManager _regionManager;
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
        }
        /// <summary>
        /// 초기 생성자
        /// </summary>
        /// <remarks>외부에서 ToolBarEvent 를 받아 AddSceneView 이벤트 획득시 RenderView 를 신규 구성하여 이를 DockingManager 에 추가함</remarks>
        /// <param name="regionManager"></param>
        [ImportingConstructor]
        public RenderingModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                if (param.ClickMenuHeader == "AddSceneView")
                {
                    IRegion r = RegionManager.Regions["DockingRegion"];
                    RenderView rView = new RenderView();
                    r.Add(new DockingMetadata(rView, new NestedDockStrategy(rView, NestedDockPosition.Right)) { Title = "Scene" });
                }
            });
        }
        RenderView mainRenderView;
        /// <summary>
        /// DynamicModule Loading 진입점
        /// </summary>
        public void Initialize()
        {
            IRegion r = RegionManager.Regions["DockingRegion"];
            mainRenderView = new RenderView();
            r.Add(new DockingMetadata(mainRenderView, new NestedDockStrategy(mainRenderView, NestedDockPosition.Left)) { Title = "Scene" });
            //r.Add(new DockingMetadata(rView, new DocumentDockStrategy()));
        }
    }
}
