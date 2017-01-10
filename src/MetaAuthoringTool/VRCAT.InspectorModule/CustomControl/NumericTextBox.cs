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
    public class NumericTextBox : TextBox
    {
        private System.Windows.Point InitPoint;
        private double defaultValue;
        private int _timeSpan;
        public NumericTextBox()
        {
            //for(int i = 0; i< this.InputBindings.Count; i++)
            //{
            //    InputBinding binder = this.InputBindings[i];
            //    int a = 10;
            //}
        }
        static NumericTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericTextBox), new FrameworkPropertyMetadata(typeof(TextBox)));
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            if (e.ClickCount == 2)
                this.Select(0, this.Text.Count());
            InitPoint = e.GetPosition(this);
            double result;
            if (Double.TryParse(this.Text, out result))
            {
                defaultValue = result;
            }
            _timeSpan = e.Timestamp;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.Timestamp - _timeSpan > 500)
                {
                    System.Windows.Point comparePoint = e.GetPosition(this);
                    if (InitPoint.X != 0.0 || InitPoint.Y != 0.0)
                    {
                        Mouse.OverrideCursor = Cursors.SizeAll;
                        double deltaVal = comparePoint.X - InitPoint.X;
                        double textVal = defaultValue + deltaVal;
                        this.Text = textVal.ToString();
                        UpdateSourceTrigger();
                    }
                }
            }
        }
        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (e.Key == Key.Enter)
        //        UpdateSourceTrigger();
        //}
        private void UpdateSourceTrigger()
        {
            BindingExpression binding = this.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}
