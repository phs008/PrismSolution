using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.Infrastructure
{
    /// <summary>
    /// Module 간 Data 전달을 위해 Pub-Sub 이벤트 클래스를 래핑함
    /// </summary>
    /// <remarks> Singleton 으로 구성하여 사용</remarks>
    public class Eventer
    {
        private static readonly Eventer eventInstance = new Eventer();
        /// <summary>
        /// Eventer 접근자
        /// </summary>
        public static Eventer Instance
        {
            get { return eventInstance; }
        }
        private IEventAggregator eventAggregator;
        /// <summary>
        /// Pub-Sub 이벤트 클래스 초기화
        /// </summary>
        public IEventAggregator EventAggregator
        {
            get
            {
                if (eventAggregator == null)
                    eventAggregator = new EventAggregator();
                return eventAggregator;
            }
        }
    }
}
