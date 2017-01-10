﻿/*See 'NOTICE.txt' for license */
using System.ComponentModel;
using System.Windows.Input;

namespace UndoRedoFramework.Core.ObjectModel
{
    /// <summary>
    /// Represents any object that manages Undo/Redo commands, and undoable properties
    /// </summary>
    public interface IUndoRedoContext
    {
        /// <summary>
        /// Registers an action with the context.
        /// </summary>
        /// <param name="action"></param>
        void RegisterAction(IUndoableAction action);
        /// <summary>
        /// Unregisters an action with the context.
        /// </summary>
        /// <param name="action"></param>
        void UnregisterAction(IUndoableAction action);

        /// <summary>
        /// Tells the context that an action has occurred.
        /// </summary>
        /// <param name="action">The action that was executed.</param>
        /// <param name="data">The data associated with the action.</param>
        void ActionExecuted(IUndoableAction action, object data);

        /// <summary>
        /// Tells the context to undo the last action executed.
        /// </summary>
        void Undo();
        /// <summary>
        /// Tells the context to redo the last action undone.
        /// </summary>
        void Redo();

        /// <summary>
        /// Returns a bool representing if this context can undo.
        /// </summary>
        /// <returns></returns>
        bool CanUndo();
        /// <summary>
        /// Returns a bool representing if this context can redo.
        /// </summary>
        /// <returns></returns>
        bool CanRedo();

        /// <summary>
        /// Returns this context's undo capabilites in the form of an ICommand.
        /// </summary>
        /// <returns></returns>
        ICommand GetUndoCommand();
        /// <summary>
        /// Returns this context's undo capabilites in the form of an ICommand.
        /// </summary>
        /// <returns></returns>
        ICommand GetRedoCommand();

        /// <summary>
        /// This event handler provides a way for this context to raise property changed notifications on behalf of the UndoableProperties.
        /// </summary>
		event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Allows the container object to raise property changed notifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
		void RaisePropertyChanged(object sender, PropertyChangedEventArgs args);
        /// <summary>
        /// Allows the container object to raise property changed notifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
		void RaisePropertyChanged(object sender, string propertyName);
    }
}
