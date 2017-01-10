using VRCAT.Infrastructure.PrismAvalonExtensions.Events;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xceed.Wpf.AvalonDock.Layout;
using Microsoft.Practices.Prism.PubSubEvents;

namespace VRCAT.Infrastructure.PrismAvalonExtensions.Regions
{
    /// <summary>
    /// Prism 의 Region 용 DockingManger Adaptor class
    /// </summary>
    public class DockingManagerRegion : Region
    {
        public DockingManagerRegion()
        {
            EventAggregator.GetEvent<CloseAllDocumentsEvent>().Subscribe(OnCloseAllDocuments);
        }
        /// <summary>
        /// 모든 Docing 창 닫기
        /// </summary>
        /// <param name="args"></param>
        private void OnCloseAllDocuments(CloseAllDocumentsEventArgs args)
        {
            Queue<object> queue = new Queue<object>(Documents.Keys);
            while (queue.Count > 0)
            {
                object view = queue.Dequeue();
                Documents[view].Close();
                if (this.Views.Contains(view))
                {
                    args.Cancel = true;
                    break;
                }
            }
        }

        IEventAggregator _eventAggregator = null;
        /// <summary>
        /// region EventAggregator 추가
        /// </summary>
        public IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null) _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                return _eventAggregator;
            }
        }

        // TODO : DockingPanel 추가 되는 부분
        /// <summary>
        /// DockingPanel 추가 기능
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <param name="viewName">Title</param>
        /// <param name="createRegionManagerScope">When true, the added view will receive a new instance of Microsoft.Practices.Prism.Regions.IRegionManager</param>
        /// <returns></returns>
        public override IRegionManager Add(object view, string viewName, bool createRegionManagerScope)
        {
            DockingMetadata md = view as DockingMetadata;
            IRegionManager rm = null;
            if (md != null)
            {
                DockingMetadataDictionary.Add(md.View, md);
                rm = base.Add(md.View, viewName, createRegionManagerScope);
                //rm = base.Add(md.View, md.View.ToString(), createRegionManagerScope);
                DockingMetadataDictionary.Remove(md.View);
            }
            else
            {
                rm = base.Add(view, viewName, createRegionManagerScope);
                //rm = base.Add(md.View, md.View.ToString(), createRegionManagerScope);
            }
            return rm;
        }

        Collection<object> _busyRemoving = new Collection<object>();
        /// <summary>
        /// Dockign Element 제거
        /// </summary>
        /// <param name="view">삭제할 Docking ContentControl</param>
        public override void Remove(object view)
        {
            if (_busyRemoving.Contains(view)) return;
            try
            {
                _busyRemoving.Add(view);
                base.Remove(view);
            }
            finally
            {
                _busyRemoving.Remove(view);
            }
        }

        Dictionary<object, DockingMetadata> _dockStrategyDictionary = new Dictionary<object, DockingMetadata>();
        /// <summary>
        /// DockingData Collection
        /// </summary>
        Dictionary<object, DockingMetadata> DockingMetadataDictionary
        {
            get { return _dockStrategyDictionary; }
        }
        /// <summary>
        /// 해당 Docking ContentControl 의 Metadata 획득
        /// </summary>
        /// <param name="view">ContentControl</param>
        /// <returns></returns>
        public DockingMetadata GetDockingMetadata(object view)
        {
            if (!DockingMetadataDictionary.ContainsKey(view)) return null;
            return DockingMetadataDictionary[view];
        }

        Dictionary<object, LayoutDocument> _documents;
        /// <summary>
        /// Docking::Document Collection
        /// </summary>
        Dictionary<object, LayoutDocument> Documents
        {
            get
            {
                if (_documents == null) _documents = new Dictionary<object, LayoutDocument>();
                return _documents;
            }
        }
        /// <summary>
        /// SubDocument 추가
        /// </summary>
        /// <param name="view">Child Element</param>
        /// <param name="document">Parent Docuemnt Element</param>
        public void RegisterCloseAction(object view, LayoutDocument document)
        {
            Documents.Add(view, document);
        }
        /// <summary>
        /// Document 삭제
        /// </summary>
        /// <param name="view">삭제될 Element</param>
        public void RemoveCloseAction(object view)
        {
            Documents.Remove(view);
        }
    }
}
