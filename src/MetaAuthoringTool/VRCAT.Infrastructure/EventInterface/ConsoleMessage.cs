using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.Infrastructure.EventInterface
{
    /// <summary>
    /// [작업중]
    /// ConsoleMessage 용 이벤트
    /// </summary>
    public class ConsoleMessage
    {
        private object _MessageFrom;

        public object MessageFrom
        {
            get { return _MessageFrom; }
            set { _MessageFrom = value; }
        }
        private object _MessageTo;

        public object MessageTo
        {
            get { return _MessageTo; }
            set { _MessageTo = value; }
        }
        private string _MessageText;

        public string MessageText
        {
            get { return _MessageText; }
            set { _MessageText = value; }
        }
    }
}
