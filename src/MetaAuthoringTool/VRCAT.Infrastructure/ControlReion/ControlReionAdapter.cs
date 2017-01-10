using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VRCAT.Infrastructure.ControlRegion
{
    /// <summary>
    /// 저작도구 Main UI 의 MenuControl 배치 용 Adapter
    /// </summary>
    public class ControlRegionAdapter : RegionAdapterBase<ContentControl>
    {
        private ContentControl _menuTarget;
        /// <summary>
        /// MenuRegion 생성자
        /// </summary>
        /// <param name="regionBehaviorFactory">저작도구 Main에 있는 Region 정보</param>
        public ControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            :base(regionBehaviorFactory)
        {
        }
        /// <summary>
        /// 저작도구 Main UI Control 에 원하는 Content 를 매칭
        /// </summary>
        /// <param name="region">저작도구 Main에 있는 Region 정보</param>
        /// <param name="regionTarget">Region 에 배치될 Content</param>
        protected override void Adapt(IRegion region, ContentControl regionTarget)
        {
            _menuTarget = regionTarget;
            region.Views.CollectionChanged += delegate
            {
                _menuTarget.Content = region.Views.FirstOrDefault();
            };
        }
        /// <summary>
        /// Template method to create a new instance of Microsoft.Practices.Prism.Regions.IRegion
        /// that will be used to adapt the object.
        /// </summary>
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
