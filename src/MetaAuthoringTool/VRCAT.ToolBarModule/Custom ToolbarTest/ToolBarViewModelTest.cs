using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCAT.DataModel;
using VRCAT.Infrastructure.DelegateCommand;
using System.Windows.Input;
using VRCAT.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;

namespace VRCAT.ToolBarModule
{
    /// <summary>
    /// ToolBar 에 대한 ViewModel 에 대해 Custom Add 및 Custom KeyGesture 처리 테스트중
    /// </summary>
    public class ToolBarViewModelTest : BindableBase
    {
        //ObservableCollection<MenuModel> _MenuItems;
        //public ObservableCollection<MenuModel> MenuItems
        //{
        //    get
        //    {
        //        if (_MenuItems == null)
        //            _MenuItems = new ObservableCollection<MenuModel>();
        //        return _MenuItems;
        //    }
        //    set { SetProperty(ref _MenuItems, value); }
        //}
        //public ToolBarViewModelTest()
        //{
        //    InitBasicMenu();
        //}
        void InitBasicMenu()
        {
            //MenuModel FileMenu = new MenuModel() { Header = "_File" };
            //MenuModel NewSceneMenu = new MenuModel() { Header = "_New Scene", MenuCommand = new CustomDelegateCommand(Command_Execute), KeyGestureValue = new KeyGesture(Key.N, ModifierKeys.Control) };
            
            //FileMenu.SubMenu.Add(NewSceneMenu);
            //MenuModel EditMenu = new MenuModel() { Header = "_Edit" };
            //MenuModel CutMenu = new MenuModel() { Header = "_Cut", MenuCommand = new CustomDelegateCommand(Command_Execute), KeyGestureValue = new KeyGesture(Key.X, ModifierKeys.Control) };
            //EditMenu.SubMenu.Add(CutMenu);
            //MenuItems.Add(FileMenu);
            //MenuItems.Add(EditMenu);
        }

        //private void Command_Execute(object obj)
        //{

        //}
        internal void PositionClick()
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("PositionGizmoClick");
            //Rendering 쪽에 메세지를 보내준다.
            
        }
        internal void RotationClick()
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("RotationGizmoClick");
            //Rendering 쪽에 메세지를 보내준다.
            
        }
        internal void ScalClick()
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("ScaleGizmoClick");
            //Rendering 쪽에 메세지를 보내준다.
            
        }
    }
}
