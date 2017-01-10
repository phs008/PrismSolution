using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VRCAT.Infrastructure.DelegateCommand
{
    /// <summary>
    /// ICommand 이벤트 바인딩을 위한 공통 DelegateCommand 구현 class
    /// </summary>
    public class CustomDelegateCommand : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;
        public CustomDelegateCommand()
        {

        }
        /// <summary>
        /// DelegateCommand 바인딩 생성자
        /// </summary>
        /// <param name="execute">EventHandler</param>
        public CustomDelegateCommand(Action<object> execute)
            : this(execute, null)
        { }
        /// <summary>
        /// DelegateCommand 바인딩 생성자
        /// </summary>
        /// <param name="execute">EventHandler</param>
        /// <param name="canExecute">EventHandler 호출 여부 체크용 Handler</param>
        public CustomDelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        /// <summary>
        /// Delegate 수행
        /// </summary>
        /// <param name="execute">수행되어질 EventHandler</param>
        public void Delegate(Action<object> execute)
        {
            _execute = execute;
        }
        /// <summary>
        /// Delegate 수행
        /// </summary>
        /// <param name="execute">수행되어질 EventHandler</param>
        /// <param name="canExecute">EventHandler 를 수행할여부를 확인하는 Handler</param>
        public void Delegate(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        /// <summary>
        /// EventHandler 수행여부 를 확인
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? _execute != null : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// 이벤트 수행
        /// </summary>
        /// <param name="parameter">이벤트 value</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _execute(parameter);
        }
    }
}
