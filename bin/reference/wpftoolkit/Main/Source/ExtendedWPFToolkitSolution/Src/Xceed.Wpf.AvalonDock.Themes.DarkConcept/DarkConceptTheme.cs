using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.Wpf.AvalonDock.Themes
{
	public class DarkConceptTheme : Theme
	{
		public override Uri GetResourceUri()
		{
			return new Uri(
				"/Xceed.Wpf.AvalonDock.Themes.DarkConcept;component/Theme.xaml",
				UriKind.Relative);
		}
	}
}
