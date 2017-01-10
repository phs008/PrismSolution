using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using VRCAT.Infrastructure;

namespace VRCAT.ToolBarModule
{
    /// <summary>
    /// Xaml 에 InputBinding에 추가된 KeyBindg 을 Window 에 추가하여 단축키 사용이 가능토록 하는 기능 추가
    /// </summary>
    public class CustomMenuItem : MenuItem
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Loaded += CustomMenuItem_Loaded;
        }

        private void CustomMenuItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.InputBindings.Count > 0)
            {
                if (this.InputBindings[0] is KeyBinding)
                {
                    KeyBinding kb = ((KeyBinding)this.InputBindings[0]);
                    if (!Application.Current.MainWindow.InputBindings.Contains(kb))
                    {
                        Application.Current.MainWindow.InputBindings.Add(kb);
                        string[] modeifiersKeys = kb.Modifiers.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (modeifiersKeys.Length > 1)
                        {
                            for (int i = 0; i < modeifiersKeys.Length; i++)
                            {
                                this.InputGestureText += modeifiersKeys[i] + " + ";
                            }
                            this.InputGestureText += kb.Key.ToString();
                        }
                        else
                            this.InputGestureText = kb.Modifiers.ToString() + " + " + kb.Key.ToString();
                    }
                }
            }
        }
    }
    /// <summary>
    /// Xaml 에 InputBinding에 추가된 KeyBindg 을 Window 에 추가하여 단축키 사용이 가능토록 하는 기능 추가
    /// </summary>
    public class CustomToggleBtn : ToggleButton
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Loaded += CustomToggleBtn_Loaded;
        }
        private void CustomToggleBtn_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.InputBindings.Count > 0)
            {
                if (this.InputBindings[0] is KeyBinding)
                {
                    KeyBinding kb = ((KeyBinding)this.InputBindings[0]);
                    Application.Current.MainWindow.InputBindings.Add(kb);
                }
            }
        }
    }
    /// <summary>
    /// Xaml 에 InputBinding에 추가된 KeyBindg 을 Window 에 추가하여 단축키 사용이 가능토록 하는 기능 추가
    /// </summary>
    public class CustomBtn : Button
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Loaded += CustomBtn_Loaded;
        }

        private void CustomBtn_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.InputBindings.Count > 0)
            {
                if (this.InputBindings[0] is KeyBinding)
                {
                    KeyBinding kb = ((KeyBinding)this.InputBindings[0]);
                    KeyBinderMultiCommand.Instance.AddKeyBinderMultiCommand(new KeyGesture(kb.Key, kb.Modifiers), kb.Command);
                    //Application.Current.MainWindow.InputBindings.Add(kb);
                }
            }
        }
    }
}
