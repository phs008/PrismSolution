using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace VRCAT.Infrastructure
{
    /// <summary>
    /// This class is an observablecollection which invokes automatically.
    /// This means that any change will be done in the right thread.
    /// </summary>
    /// <typeparam name="T">The type of the elements</typeparam>
    public class DispatchingObservableCollection<T> : ObservableCollection<T>
    {
        /// <summary>
        /// The default constructor of the ObservableCollection
        /// </summary>
        public DispatchingObservableCollection()
        {
            //Assign the current Dispatcher (owner of the collection)
            _currentDispatcher = Dispatcher.CurrentDispatcher;
        }

        private readonly Dispatcher _currentDispatcher;

        /// <summary>
        /// Executes this action in the right thread
        /// </summary>
        ///<param name="action">The action which should be executed</param>
        private void DoDispatchedAction(Action action)
        {
            if (_currentDispatcher.CheckAccess())
                action.Invoke();
            else
                _currentDispatcher.Invoke(DispatcherPriority.Send, action);
        }

        /// <summary>
        /// Clears all items
        /// </summary>
        protected override void ClearItems()
        {
            DoDispatchedAction(() => base.ClearItems());
        }

        /// <summary>
        /// Inserts a item at the specified index
        /// </summary>
        ///<param name="index">The index where the item should be inserted</param>
        ///<param name="item">The item which should be inserted</param>
        protected override void InsertItem(int index, T item)
        {
            DoDispatchedAction(() => base.InsertItem(index, item));
        }

        /// <summary>
        /// Moves an item from one index to another
        /// </summary>
        ///<param name="oldIndex">The index of the item which should be moved</param>
        ///<param name="newIndex">The index where the item should be moved</param>
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            DoDispatchedAction(() => base.MoveItem(oldIndex, newIndex));
        }

        /// <summary>
        /// Removes the item at the specified index
        /// </summary>
        ///<param name="index">The index of the item which should be removed</param>
        protected override void RemoveItem(int index)
        {
            DoDispatchedAction(() => base.RemoveItem(index));
        }

        /// <summary>
        /// Sets the item at the specified index
        /// </summary>
        ///<param name="index">The index which should be set</param>
        ///<param name="item">The new item</param>
        protected override void SetItem(int index, T item)
        {
            DoDispatchedAction(() => base.SetItem(index, item));
        }

        /// <summary>
        /// Fires the CollectionChanged Event
        /// </summary>
        ///<param name="e">The additional arguments of the event</param>
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DoDispatchedAction(() => base.OnCollectionChanged(e));
        }

        /// <summary>
        /// Fires the PropertyChanged Event
        /// </summary>
        ///<param name="e">The additional arguments of the event</param>
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            DoDispatchedAction(() => base.OnPropertyChanged(e));
        }
    }
}
