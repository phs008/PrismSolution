/*See 'NOTICE.txt' for license */
namespace UndoRedoFramework.Core.ObjectModel
{
    /// <summary>
    /// Represents an undoable action.
    /// </summary>
    public interface IUndoableAction
    {
        /// <summary>
        /// An optional name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// An undo method.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Undo(object data);
        /// <summary>
        /// A redo method.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Redo(object data);
    }
}
