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

namespace ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class PuzzleViewModel
    {
        public PuzzleViewModel(Puzzle puzzle)
        {
            // var puzzle = Puzzle.FromRowStrings(
            //    "xxxxx",
            //    "x...x",
            //    "x...x",
            //    "x...x",
            //    "xxxxx"
            //);
            this.PuzzleToPlay = puzzle;
        }

        public Puzzle PuzzleToPlay
        {
            set
            {
                var facade = new PiCrossFacade();
                var playablePuzzle = facade.CreatePlayablePuzzle(value);

                this.Grid = playablePuzzle.Grid;
                this.RowConstraints = playablePuzzle.RowConstraints;
                this.ColumnConstraints = playablePuzzle.ColumnConstraints;
                this.FillSquareCommand = new TagSquareCommand(Square.FILLED);
                this.EmptySquareCommand = new TagSquareCommand(Square.EMPTY);
                this.IsSolved = playablePuzzle.IsSolved;
            }
        }

        public IGrid<IPlayablePuzzleSquare> Grid { get; private set; }
        public ISequence<IPlayablePuzzleConstraints> RowConstraints { get; private set; }
        public ISequence<IPlayablePuzzleConstraints> ColumnConstraints { get; private set; }
        public TagSquareCommand FillSquareCommand { get; private set; }
        public TagSquareCommand EmptySquareCommand { get; private set; }
        public Cells.Cell<bool> IsSolved { get; private set; }
        //public object EmptySquare { get; private set; }
        //public object FilledSquare { get; private set; }
        //public object UnknownSquare { get; private set; }
    }

}