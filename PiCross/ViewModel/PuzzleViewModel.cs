using PiCross;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataStructures;
using Cells;

namespace ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class PuzzleViewModel
    {
        public PuzzleViewModel(Puzzle puzzle)
        {
            var testpuzzle = Puzzle.FromRowStrings(
               "xxxxx",
               "x...x",
               "x...x",
               "x...x",
               "xxxxx"
           );
            //this.PuzzleToPlay = puzzle;
            this.PuzzleToPlay = testpuzzle;
        }

        public Puzzle PuzzleToPlay
        {
            set
            {
                var facade = new PiCrossFacade();
                var playablePuzzle = facade.CreatePlayablePuzzle(value);

                this.Grid = populateGrid(playablePuzzle.Grid);
                this.RowConstraints = playablePuzzle.RowConstraints;
                this.ColumnConstraints = playablePuzzle.ColumnConstraints;
                this.IsSolved = playablePuzzle.IsSolved;
            }
        }

        private IGrid<ViewModelSquare> populateGrid(IGrid<IPlayablePuzzleSquare> grid)
        {
            var vmgrid = grid.Map((IPlayablePuzzleSquare domainPuzzle) => new ViewModelSquare(domainPuzzle));
            return vmgrid.Copy();
        }

        public IGrid<ViewModelSquare> Grid { get; private set; }
        public ISequence<IPlayablePuzzleConstraints> RowConstraints { get; private set; }
        public ISequence<IPlayablePuzzleConstraints> ColumnConstraints { get; private set; }
        public Cell<bool> IsSolved { get; private set; }
    }

    public class ViewModelSquare
    {
        private readonly IPlayablePuzzleSquare _square;

        public ViewModelSquare(IPlayablePuzzleSquare square)
        {
            this._square = square;
            this.FillSquare = new EnabledCommand(() => square.Contents.Value = Square.FILLED);
            this.EmptySquare = new EnabledCommand(() => square.Contents.Value = Square.EMPTY);
        }

        public Cell<Square> Contents { get { return _square.Contents; } }

        public ICommand FillSquare { get; }
        public ICommand EmptySquare { get;}
    }

    public class EnabledCommand : ICommand
    {
        private readonly Action action;

        public EnabledCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}