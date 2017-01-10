using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure.PrismAvalonExtensions;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using VRCAT.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.DataModel;

namespace VRCAT.AssetModule
{
    /// <summary>
    /// 해당 Assembly 를 DynamicModule 로 구성하기 위한 진입점
    /// </summary>
    [ModuleExport(typeof(AssetModule))]
    public class AssetModule : IModule
    {
        IRegionManager _regionManager;
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
        }
        /// <summary>
        /// 초기 생성자
        /// </summary>
        /// <remarks>외부에서 ToolBarEvent 를 받아 AddAssetView 이벤트 획득시 AssetView 를 신규 구성하여 이를 DockingManager 에 추가함</remarks>
        /// <param name="regionManager"></param>
        [ImportingConstructor]
        public AssetModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                if (param.ClickMenuHeader == "AddAssetView")
                {
                    IRegion r = RegionManager.Regions["DockingRegion"];
                    AssetView newView = new AssetView();
                    r.Add(new DockingMetadata(newView, new NestedDockStrategy(newView, NestedDockPosition.Left)) { Title = "Project" });
                }
            });
        }
        /// <summary>
        /// DynamicModule Loading 진입점
        /// </summary>
        public void Initialize()
        {
            IRegion r = RegionManager.Regions["DockingRegion"];
            r.Add(new DockingMetadata(AssetView, new NestedDockStrategy(AssetView, NestedDockPosition.Left)) { Title = "Project" });
        }

        [Import]
        AssetView _assetView = null;
        /// <summary>
        /// AssetView 가 무조건 올라오게 되어있음
        /// </summary>
        public AssetView AssetView
        {
            get { return _assetView; }
        }
    }
}
