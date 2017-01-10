using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VRCAT.Infrastructure
{
    /// <summary>
    /// MenuModel 동적 구성시 MenuModel 에 기입된 Gesture 에 대한 동적 바인딩용 Class
    /// </summary>
    public class InputBindingBehavior
    {
        public static bool GetPropagateInputBindingsToWindow(FrameworkElement obj)
        {
            return (bool)obj.GetValue(PropagateInputBindingsToWindowProperty);
        }

        public static void SetPropagateInputBindingsToWindow(FrameworkElement obj, bool value)
        {
            obj.SetValue(PropagateInputBindingsToWindowProperty, value);
        }

        public static readonly DependencyProperty PropagateInputBindingsToWindowProperty =
            DependencyProperty.RegisterAttached("PropagateInputBindingsToWindow", typeof(bool), typeof(InputBindingBehavior),
            new PropertyMetadata(false, OnPropagateInputBindingsToWindowChanged));

        private static void OnPropagateInputBindingsToWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FrameworkElement)d).Loaded += frameworkElement_Loaded;
        }
        /// <summary>
        /// 해당 UI 에 Gesutre 를 매핑하는 함수
        /// </summary>
        /// <param name="sender">FrameworkElement</param>
        private static void frameworkElement_Loaded(object sender, RoutedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;
            frameworkElement.Loaded -= frameworkElement_Loaded;

            var window = Window.GetWindow(frameworkElement);
            if (window == null)
            {
                return;
            }

            // Move input bindings from the FrameworkElement to the window.
            for (int i = frameworkElement.InputBindings.Count - 1; i >= 0; i--)
            {
                var inputBinding = (InputBinding)frameworkElement.InputBindings[i];
                window.InputBindings.Add(inputBinding);
                frameworkElement.InputBindings.Remove(inputBinding);
            }
        }
    }
}
