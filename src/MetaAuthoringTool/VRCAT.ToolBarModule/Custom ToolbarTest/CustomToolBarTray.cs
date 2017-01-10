using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace VRCAT.ToolBarModule
{
    /// <summary>
    /// 테스트용 수행
    /// </summary>
    //public class CustomToolBarTray : ToolBarTray
    //{
    //    private ObservableCollection<ToolBar> Toolbar = new ObservableCollection<ToolBar>();
    //    private ContextMenu subContextMenu = new ContextMenu();
    //    public CustomToolBarTray()
    //    {
    //        //this.DataContext = new ToolBarViewModel();
    //        //TODO: ContextMenu를 통해 사용자 정의 메뉴 생성을 위해 작업중인 코드
    //        MenuItem subMenu = new MenuItem() { Header = "AddUserToolBar", Tag = subContextMenu };
    //        subContextMenu.Items.Add(subMenu);
    //    }
    //    public override void EndInit()
    //    {
    //        base.EndInit();
    //        ToolBar MainToolBar = base.ToolBars[0];
    //        subItems(MainToolBar.Items);
    //    }

    //    /// <summary>
    //    /// MenuItem 하위에 SubContextMenu 추가
    //    /// </summary>
    //    /// <param name="parentCol"></param>
    //    public void subItems(ItemCollection parentCol)
    //    {
    //        foreach(var Child in parentCol)
    //        {
    //            if (Child is Menu)
    //            {
    //                subItems((Child as Menu).Items);
    //                (Child as Menu).ContextMenu = subContextMenu;
    //                subContextMenu.Tag = (Child as Menu);
    //            }
    //            else if (Child is MenuItem)
    //            {
    //                subItems((Child as MenuItem).Items);
    //                (Child as MenuItem).ContextMenu = subContextMenu;
    //                subContextMenu.Tag = (Child as MenuItem);
    //            }
    //            else
    //                continue;
    //        }
    //    }
    //}
}
