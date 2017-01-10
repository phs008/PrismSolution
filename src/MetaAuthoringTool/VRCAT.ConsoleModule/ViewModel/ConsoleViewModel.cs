using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using VRCAT.Infrastructure.EventInterface;
using VRCAT.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.Infrastructure.MonitoredUndo;
using System.Windows.Data;
using System.Windows;
using MVRWrapper;

namespace VRCAT.ConsoleModule
{
    public class ConsoleViewModel : BindableBase
    {
        public DelegateCommand MessageConsoleClearCommand { get; private set; }
        private ObservableCollection<ConsoleMessage> _collectMessage;

        public ObservableCollection<ConsoleMessage> CollectMessage
        {
            get
            {
                if (_collectMessage == null)
                    _collectMessage = new ObservableCollection<ConsoleMessage>();
                return _collectMessage;
            }
            set { _collectMessage = value; }
        }

        public IEnumerable<ChangeSet> UndoStack
        {
            get { return UndoService.Current[this].UndoStack; }
        }
        public IEnumerable<ChangeSet> RedoStack
        {
            get { return UndoService.Current[this].RedoStack; }
        }

        

        private ConsoleView _View;
        public ConsoleViewModel(ConsoleView param)
        {
            _View = param;
            //var root = UndoService.Current[this];
            //root.UndoStackChanged += root_UndoStackChanged;
            //root.RedoStackChanged += root_RedoStackChanged;
            /////LOG 이벤트 에 대한 Subscribe 처리
            //Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe
            //    (param =>
            //        {
            //          CollectMessage.Add(new ConsoleMessage() { MessageFrom = "", MessageTo = "", MessageText = param });
            //        }
            //    );

            /////MessageClearCommand 처리
            MLog.GetInstance();
            MessageConsoleClearCommand = new DelegateCommand(MessageClear);
            MLog.E += MLog_E;
        }

        private delegate void TextBoxDelegate(string arg);
        private void MLog_E(string s)
        {
            _View.ConsoleTextBox.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                new TextBoxDelegate(UpdateText), s);

        }

        private void UpdateText(string arg)
        {
            _View.ConsoleTextBox.Text += arg + "\n";
            _View.ConsoleTextBox.ScrollToEnd();
        }

        void root_RedoStackChanged(object sender, EventArgs e)
        {
            RefreshStackList();
        }

        void root_UndoStackChanged(object sender, EventArgs e)
        {
            RefreshStackList();
        }

        void RefreshStackList()
        {
            var cv = CollectionViewSource.GetDefaultView(UndoStack);
            cv.Refresh();
            cv = CollectionViewSource.GetDefaultView(RedoStack);
            cv.Refresh();
        }
        public void MessageClear()
        {
            CollectMessage.Clear();
        }
    }
}