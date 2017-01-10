using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace VRCAT.Infrastructure.PrismAvalonExtensions
{
    /// <summary>
    /// Dock Serialization Helper 클래스
    /// </summary>
    public class SerializationHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="dm">최상위 DockingManager</param>
        /// <param name="filename">Layout 이 저장될 filepath</param>
        public static void Serialize(DockingManager dm, string filename)
        {
            XmlLayoutSerializer s = new XmlLayoutSerializer(dm);
            s.Serialize(filename);
        }


        static List<string> ContentIDList = new List<string>();
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="dm">최상위 DockingManager</param>
        /// <param name="regionName">[사용안함]</param>
        /// <param name="filename">Layout Path</param>
        public static void Deserialize(DockingManager dm, string regionName, string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (!fi.Exists) return;

            XmlLayoutSerializer s = new XmlLayoutSerializer(dm);
            s.LayoutSerializationCallback += (sender, e) =>
            {
                if (ContentIDList.Exists(a => a == e.Model.ContentId))
                {
                    if (e.Content != null)
                    {
                        object o = Activator.CreateInstance(e.Content.GetType());
                        e.Content = o;
                    }
                }
                else
                {
                    ContentIDList.Add(e.Model.ContentId);
                }
            };
            s.Deserialize(filename);
        }
    }
}
