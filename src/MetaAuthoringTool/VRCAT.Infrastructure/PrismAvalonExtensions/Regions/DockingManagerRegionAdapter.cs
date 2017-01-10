using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xceed.Wpf.AvalonDock;

namespace VRCAT.Infrastructure.PrismAvalonExtensions.Regions
{
    /// <summary>
    /// 저작도구 Main UI 의 Docking 배치 용 Adapter
    /// </summary>
    public class DockingManagerRegionAdapter : RegionAdapterBase<DockingManager>
    {
        /// <summary>
        /// DockingRegion 생성자
        /// </summary>
        /// <param name="regionBehaviorFactory">저작도구 Main에 있는 Region 정보</param>
        public DockingManagerRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
        }

        protected override IRegion CreateRegion()
        {
            return new DockingManagerRegion();
        }
        /// <summary>
        /// 초기 Attach 생성자
        /// </summary>
        /// <remarks>맨 처음 region 에 dockingmanger 을 Contentscontrol 로 추가한다.</remarks>
        /// <param name="region">DockingManager 이 붙을 region</param>
        /// <param name="regionTarget">DockingManager</param>
        protected override void AttachBehaviors(IRegion region, DockingManager regionTarget)
        {
            if (region == null) throw new System.ArgumentNullException("region");
            region.Behaviors.Add(DockingManagerBehavior.BehaviorKey, new DockingManagerBehavior() { HostControl = regionTarget });
            base.AttachBehaviors(region, regionTarget);
        }
    }
}
