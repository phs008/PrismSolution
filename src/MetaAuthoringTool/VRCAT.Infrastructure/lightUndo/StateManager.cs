using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.Infrastructure
{
    public class StateManager  : BindableBase
    {
        static StateManager _Instance;
        //private Stack<UndoCommand> commands = new Stack<UndoCommand>();
        List<UndoCommand> commands = new List<UndoCommand>();
        int pointIdx = -1;

        public static StateManager Instance
        {
            get
            {
                if (null == _Instance)
                    _Instance = new StateManager();
                return _Instance;
            }
        }
        public void ChangeSet(UndoCommand command)
        {
            command.Execute();
            //commands.Push(command);
            commands.Add(command);
            pointIdx = commands.Count - 1;
        }
        public void UndoState()
        {
            if (pointIdx > -1)
            {
                var command = commands.ElementAt(pointIdx);
                command.Undo();
                pointIdx -= 1;
            }
        }
        public void RedoState()
        {
            if (pointIdx > -1)
            {
                var command = commands.ElementAt(pointIdx + 1);
                command.Execute();
                pointIdx += 1;
            }
        }
    }
}
