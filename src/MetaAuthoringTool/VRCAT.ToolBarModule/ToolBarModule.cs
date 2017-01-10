using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VRCAT.Infrastructure.PrismAvalonExtensions;

namespace VRCAT.ToolBarModule
{
    /// <summary>
    /// 해당 Assembly 를 DynamicModule 로 구성하기 위한 진입점
    /// </summary>
    [ModuleExport(typeof(ToolBarModule))]
    public class ToolBarModule : IModule
    {
        IRegionManager _regionManager;
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
        }
        /// <summary>
        /// 초기 생성자
        /// </summary>
        /// <param name="regionManager"></param>
        [ImportingConstructor]
        public ToolBarModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        /// <summary>
        /// DynamicModule Loading 진입점
        /// </summary>
        public void Initialize()
        {
            IRegion r = RegionManager.Regions["ToolBarControl"];
            ToolBarView _view = new ToolBarView();
            r.Add(_view);
            //r.Add(ToolbarView);
        }

        //[Import]
        //ToolBarView _anotherToolbarView = null;
        //public ToolBarView AnotherToolbarView
        //{
        //    get 
        //    {
        //        _anotherToolbarView.InitDataContextChildControl(ToolbarViewModel);
        //        ToolbarViewModel.RegionManager = this._regionManager;
        //        return _anotherToolbarView; 
        //    }
        //}
        //[Import]
        //ToolBarViewModel _toolbarViewModel = null;
        //public ToolBarViewModel ToolbarViewModel
        //{
        //    get { return _toolbarViewModel; }
        //}

        //[Import]
        //ToolbarViewTest _toolbarView = null;
        //public ToolbarViewTest ToolbarView
        //{
        //    get { return _toolbarView; }
        //}
    }
}
