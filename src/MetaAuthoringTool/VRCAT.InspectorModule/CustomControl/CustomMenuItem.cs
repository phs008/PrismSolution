using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace VRCAT.InspectorModule
{
    public class CustomMenuItem : MenuItem
    {
        public CustomMenuItem(object DataContext)
        {
            this.Header = "Remove Component";
            if(DataContext is PropertyGroupViewModel)
            {
                this.Command = ((PropertyGroupViewModel)DataContext).DeleteCommand;
            }
            else if(DataContext is ScriptViewModel)
            {
                this.Command = ((ScriptViewModel)DataContext).DeleteCommand;
            }
            else if(DataContext is MaterialViewModel)
            {
                
            }
            else if(DataContext is AnimationViewModel)
            {

            }
            
        }
    }
}
