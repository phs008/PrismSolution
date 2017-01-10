using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using VRCAT.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Windows;
using VRCAT.DataModel;

namespace VRCAT.VirtualUserModule
{
    /// <summary>
    /// 해당 Assembly 를 DynamicModule 로 구성하기 위한 진입점
    /// </summary>
    [ModuleExport(typeof(VirtualUserModule))]
    public class VirtualUserModule : IModule
    {
        VirtualView _Threeview;
        OneDoF _Oneview;
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
        public VirtualUserModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                this.HandleEvent(param.ClickMenuHeader);
            });
        }
        void HandleEvent(string param)
        {
            if (param.Equals("ThreeDOF"))
            {
                if (this._Threeview == null)
                {
                    this._Threeview = new VirtualView();
                    this._Threeview.Owner = Application.Current.MainWindow;
                }
                this._Threeview.Show();
            }
            else if(param.Equals("OneDOF"))
            {
                if(this._Oneview == null)
                {
                    this._Oneview = new OneDoF();
                    this._Oneview.Owner = Application.Current.MainWindow;
                }
                this._Oneview.Show();
            }
        }

        public void Initialize()
        {
        }
    }
}
