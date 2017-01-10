using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VRCAT.DataModel
{
    /// <summary>
    /// [작업중]
    /// MenuModel Class
    /// </summary>
    public class MenuModel : BindableBase
    {
        /// <summary>
        /// MenuModel 생성자
        /// </summary>
        public MenuModel()
        {
            SubMenu.CollectionChanged += SubMenu_CollectionChanged;
        }
        /// <summary>
        /// 하위 메뉴 추가 감지
        /// </summary>
        /// <param name="sender">SubMenuModel</param>
        /// <param name="e">NotifyCollectionChangedEventArgs argument</param>
        void SubMenu_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                OnPropertyChanged("SubMenu");
            }
            else if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                OnPropertyChanged("SubMenu");
            }
        }
        string _Header;
        /// <summary>
        /// Menu Header 이름
        /// </summary>
        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }
        string _InputGestureText;
        /// <summary>
        /// Menu 단축키 Text
        /// </summary>
        public string InputGestureText 
        {
            get { return _InputGestureText; }
            set { SetProperty(ref _InputGestureText, value); }
        }
        /// <summary>
        /// Menu별 Click Command
        /// </summary>
        public ICommand MenuCommand { get; set; }

        KeyGesture _KeyGestureValue ;
        /// <summary>
        /// Menu 단축키
        /// </summary>
        public KeyGesture KeyGestureValue 
        {
            get { return _KeyGestureValue; }
            set
            {
                SetProperty(ref _KeyGestureValue, value);
                InputGestureText =  value.Modifiers.ToString() + "+" + value.Key.ToString();
            }
        }

        ObservableCollection<MenuModel> _SubMenu;
        /// <summary>
        /// SumMenu 리스트
        /// </summary>
        public ObservableCollection<MenuModel> SubMenu 
        {
            get
            {
                if (_SubMenu == null)
                    _SubMenu = new ObservableCollection<MenuModel>();
                return _SubMenu;
            }
            set { SetProperty(ref _SubMenu, value); }
        }
    }
}
