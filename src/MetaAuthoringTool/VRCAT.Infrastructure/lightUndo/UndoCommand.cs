using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.Infrastructure
{
    public class UndoCommand
    {
        private readonly Action _action;
        private readonly Action _undoAction;
        /// <summary>
        /// Undo 에 대한 Command 추가
        /// </summary>
        /// <param name="action">Do Action</param>
        /// <param name="undoAction">Undo Action</param>
        public UndoCommand(Action action, Action undoAction)
        {
            _undoAction = undoAction;
            _action = action;
        }
        public void Execute()
        {
            _action();
        }
        public void Undo()
        {
            _undoAction();
        }
    }
}
