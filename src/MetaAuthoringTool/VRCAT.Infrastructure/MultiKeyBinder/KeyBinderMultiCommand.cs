using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFXCommand;

namespace VRCAT.Infrastructure
{
    public class KeyBinderMultiCommand 
    {
        //List<KeyGesture> keyList = new List<KeyGesture>();
        List<KeyGestureModel> KeyList = new List<KeyGestureModel>();
        static KeyBinderMultiCommand _Instance;
        public static KeyBinderMultiCommand Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new KeyBinderMultiCommand();
                return _Instance;
            }
        }
        private void VirtualCommandExecute(object obj)
        {
            if (obj != null && obj is KeyGesture)
            {
                KeyGesture gesture = (KeyGesture)obj;
                IEnumerable<KeyGestureModel> getData = KeyList.Where(a => a.gesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture) == gesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture)).Select(a => a);
                if(getData.Count() >0)
                {
                    foreach (ICommand realCommand in getData.First().realCommandList)
                    {
                        object param = null;
                        if (realCommand is RelayCommand)
                            param = ((RelayCommand)realCommand)._CommandParameter;
                        realCommand.Execute(param);
                    }
                }
            }
            //foreach (ICommand command in RealCommandsList)
            //    command.Execute(obj);

        }
        public void AddKeyBinderMultiCommand(KeyGesture gesture, ICommand addCommand)
        {
            IEnumerable<KeyGestureModel> getData = KeyList.Where(a => a.gesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture) == gesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture)).Select(a => a);
            /// 이미 key 가 있는 경우
            if(getData.Count() > 0)
            {
                getData.First().realCommandList.Add(addCommand);
            }
            else
            {
                ICommand command = new RelayCommand(VirtualCommandExecute, gesture);
                KeyBinding keybinder = new KeyBinding(command, gesture);
                KeyGestureModel gm = new KeyGestureModel(gesture);
                gm.realCommandList.Add(addCommand);
                KeyList.Add(gm);
                Application.Current.MainWindow.InputBindings.Add(keybinder);
            }
        }
    }
    class KeyGestureModel
    {
        public readonly KeyGesture gesture;
        public List<ICommand> realCommandList = new List<ICommand>();
        public KeyGestureModel(KeyGesture param)
        {
            gesture = param;
        }
    }

}
