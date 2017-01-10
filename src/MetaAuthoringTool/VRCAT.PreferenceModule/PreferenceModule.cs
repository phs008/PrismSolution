using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using VRCAT.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.DataModel;

namespace VRCAT.PreferenceModule
{
    [ModuleExport(typeof(PreferenceModule))]
    public class PreferenceModule : IModule
    {
        public PreferenceModule()
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                if(param.ClickMenuHeader == "ProjectSetting")
                {
                    PreferenceView pView = new PreferenceView();
                    pView.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    pView.Show();
                }
            });
        }
        public void Initialize()
        {
        }
    }
}
