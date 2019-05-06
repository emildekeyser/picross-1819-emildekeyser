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
        public PuzzleViewModel()
        {
            //var puzzle = Puzzle.GenerateRandom(8, 8);
            var puzzle = Puzzle.FromRowStrings(
               "xxxxx",
               "x...x",
               "x...x",
               "x...x",
               "xxxxx"
           );

            var facade = new PiCrossFacade();
            var playablePuzzle = facade.CreatePlayablePuzzle(puzzle);
            //playablePuzzle.Grid[new Vector2D(0, 0)].Contents.Value = Square.FILLED;
            //playablePuzzle.Grid[new Vector2D(1, 0)].Contents.Value = Square.EMPTY;

            this.Grid = playablePuzzle.Grid;
            this.RowConstraints = playablePuzzle.RowConstraints;
            this.ColumnConstraints = playablePuzzle.ColumnConstraints;
            this.FillSquareCommand = new TagSquareCommand(Square.FILLED);
            this.EmptySquareCommand = new TagSquareCommand(Square.EMPTY);
            this.IsSolved = playablePuzzle.IsSolved;

            //this.EmptySquare = Square.EMPTY;
            //this.FilledSquare = Square.FILLED;
            //this.UnknownSquare = Square.UNKNOWN;
        }

        //public object EmptySquare { get; private set; }
        //public object FilledSquare { get; private set; }
        //public object UnknownSquare { get; private set; }

        public IGrid<IPlayablePuzzleSquare> Grid { get; }
        public ISequence<IPlayablePuzzleConstraints> RowConstraints { get; }
        public ISequence<IPlayablePuzzleConstraints> ColumnConstraints { get; }
        public TagSquareCommand FillSquareCommand { get; }
        public TagSquareCommand EmptySquareCommand { get; }
        public Cells.Cell<bool> IsSolved { get; }
    }

}