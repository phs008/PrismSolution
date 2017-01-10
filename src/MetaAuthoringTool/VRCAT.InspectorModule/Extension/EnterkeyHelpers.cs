using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace VRCAT.InspectorModule
{
    public static class EnterkeyHelpers
    {
        public static readonly DependencyProperty EnterKeyCommandProperty = DependencyProperty.RegisterAttached(
            "EnterKeyCommand",
            typeof(ICommand),
            typeof(EnterkeyHelpers),
            new PropertyMetadata(null, OnEnterKeyCommandChanged));
        private static void OnEnterKeyCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = (ICommand)e.NewValue;
            FrameworkElement fe = (FrameworkElement)d;
            Control control = (Control)d;
            control.KeyDown += (s, args) =>
            {
                if (args.Key == Key.Enter)
                {
                    // make sure the textbox binding updates its source first
                    BindingExpression b = control.GetBindingExpression(TextBox.TextProperty);
                    if (b != null)
                    {
                        b.UpdateSource();
                    }
                    command.Execute(null);
                }
            };
        }
        public static ICommand GetEnterKeyCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(EnterKeyCommandProperty);
        }
        public static void SetEnterKeyCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(EnterKeyCommandProperty, value);
        }
    }
}
