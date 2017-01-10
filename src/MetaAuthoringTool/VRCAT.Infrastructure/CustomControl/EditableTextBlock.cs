using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace VRCAT.Infrastructure
{
    /// <summary>
    /// F2 를 눌렀을때 이름 변경할수 있는 Editable 특수 Textblock
    /// </summary>
    public class EditableTextBlock : TextBlock
    {
        /// <summary>
        /// EditMode 상태 변경
        /// </summary>
        public bool IsInEditMode
        {
            get
            {
                return (bool)GetValue(IsInEditModeProperty);
            }
            set
            {
                SetValue(IsInEditModeProperty, value);
            }
        }

        private EditableTextBlockAdorner _adorner;
        
        /// <summary>
        /// EditModel 진입용 DependencyProperty
        /// </summary>
        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditableTextBlock), new UIPropertyMetadata(false, IsInEditModeUpdate));

        /// <summary>
        /// Binding 된 IsInEditModel 값 변화시 발생하는 Event
        /// </summary>
        /// <param name="obj">EditableTextBlock</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> event data</param>
        private static void IsInEditModeUpdate(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            EditableTextBlock textBlock = obj as EditableTextBlock;
            if (null != textBlock)
            {
                //Get the adorner layer of the uielement (here TextBlock)
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(textBlock);

                if (layer != null)
                {
                    //If the IsInEditMode set to true means the user has enabled the edit mode then
                    //add the adorner to the adorner layer of the TextBlock.
                    if (textBlock.IsInEditMode)
                    {
                        if (null == textBlock._adorner)
                        {
                            textBlock._adorner = new EditableTextBlockAdorner(textBlock);

                            //Events wired to exit edit mode when the user presses Enter key or leaves the control.
                            textBlock._adorner.TextBoxKeyUp += textBlock.TextBoxKeyUp;
                            textBlock._adorner.TextBoxLostFocus += textBlock.TextBoxLostFocus;
                        }
                        layer.Add(textBlock._adorner);
                    }
                    else
                    {
                        //Remove the adorner from the adorner layer.
                        Adorner[] adorners = layer.GetAdorners(textBlock);
                        if (adorners != null)
                        {
                            foreach (Adorner adorner in adorners)
                            {
                                if (adorner is EditableTextBlockAdorner)
                                {
                                    layer.Remove(adorner);
                                }
                            }
                        }

                        //Update the textblock's text binding.
                        BindingExpression expression = textBlock.GetBindingExpression(TextProperty);
                        if (null != expression)
                        {
                            expression.UpdateTarget();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// TextBlock MaxLength
        /// </summary>
        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for MaxLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(EditableTextBlock), new UIPropertyMetadata(0));

        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            IsInEditMode = false;
        }

        /// <summary>
        /// Key Release
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> event data</param>
        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Enter)
            {
                IsInEditMode = false;
            }
        }
        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseDown"/> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. This event data reports details about the mouse button that was pressed and the handled state.</param>
        //protected override void OnMouseDown(MouseButtonEventArgs e)
        //{
        //    if (e.MiddleButton == MouseButtonState.Pressed)
        //    {
        //        IsInEditMode = true;
        //    }
        //    else if (e.ClickCount == 2)
        //    {
        //        IsInEditMode = true;
        //    }
        //}
    }
}
