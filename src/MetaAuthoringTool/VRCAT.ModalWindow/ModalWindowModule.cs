using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;

namespace VRCAT.CustomModalWindow
{
    /// <summary>
    /// 해당 Assembly 를 DynamicModule 로 구성하기 위한 진입점
    /// </summary>
	[ModuleExport(typeof(ModalWindowModule))]
	public class ModalWindowModule : IModule
	{
        ModalViewModel mv;
        /// <summary>
        /// DynamicModule Loading 진입점
        /// </summary>
		public void Initialize()
		{
			mv = new ModalViewModel();
		}
	}
}
