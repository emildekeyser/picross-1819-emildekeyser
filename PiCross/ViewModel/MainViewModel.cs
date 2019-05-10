using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this._gameData = new PiCrossFacade().LoadGameData(".\\picross.zip");
            this._welcomeScreen = new WelcomeViewModel( new StartPuzzleCommand(this), this._gameData.PuzzleLibrary.Entries);
            this._puzzleScreen = new PuzzleViewModel(this._gameData.PuzzleLibrary.Entries.First().Puzzle);
            this.CurrentScreen = new ConcreteCell<object>();
            this.CurrentScreen.Value = this._welcomeScreen;

        }

        private IGameData _gameData;
        private WelcomeViewModel _welcomeScreen;
        private PuzzleViewModel _puzzleScreen;

        public Cell<object> CurrentScreen { get; private set; }

        internal class StartPuzzleCommand : ICommand
        {
            public StartPuzzleCommand(MainViewModel _mainViewModel)
            {
                this._mainViewModel = _mainViewModel;
            }
            private MainViewModel _mainViewModel;

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                var selectedPuzzleEntry = (IPuzzleLibraryEntry)parameter;
                if(selectedPuzzleEntry != null)
                {
                    this._mainViewModel._puzzleScreen.PuzzleToPlay = selectedPuzzleEntry.Puzzle;
                }
                this._mainViewModel.CurrentScreen.Value = this._mainViewModel._puzzleScreen;
            }
        }
    }
}
