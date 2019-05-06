using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class TagSquareCommand : ICommand
    {
        private Square squareType;

        public TagSquareCommand(Square squareType)
        {
            this.squareType = squareType;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //var square = (IPlayablePuzzleSquare) parameter;
            //return square.Contents.Value == Square.UNKNOWN;
            return true;
        }

        public void Execute(object parameter)
        {
            var square = (IPlayablePuzzleSquare) parameter;
            square.Contents.Value = this.squareType;
        }
    }
}
