using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.PrismAvalonExtensions;

namespace VRCAT.InspectorModule
{
    [ModuleExport(typeof(InspectorModule))]
    public class InspectorModule : IModule
    {
        IRegionManager _regionManager;
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
        }
        [ImportingConstructor]
        public InspectorModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(param =>
            {
                if (param == "AddInspectorView")
                {
                    IRegion r = RegionManager.Regions["DockingRegion"];
                    InspectorView rView = new VRCAT.InspectorModule.InspectorView();
                    r.Add(new DockingMetadata(rView, new NestedDockStrategy(rView, NestedDockPosition.Right)) { Title = "Inspector" });
                }
            });
        }
        public void Initialize()
        {
            IRegion r = RegionManager.Regions["DockingRegion"];
            r.Add(new DockingMetadata(InspectorView, new NestedDockStrategy(InspectorView, NestedDockPosition.Right | NestedDockPosition.Bottom)) { Title = "Inspector" });
        }
        [Import]
        InspectorView _inspectorView = null;
        public InspectorView InspectorView
        {
            get { return _inspectorView; }
        }
    }
}
