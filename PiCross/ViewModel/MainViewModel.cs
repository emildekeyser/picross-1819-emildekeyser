using Cells;
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
        private object _currentScreen;

        public MainViewModel()
        {
            this.WelcomeScreen = new WelcomeViewModel( new StartPuzzleCommand(this));
            this.PuzzleScreen = new PuzzleViewModel();
            this.CurrentScreen = new ConcreteCell<object>();
            this.CurrentScreen.Value = this.WelcomeScreen;

        }

        private object WelcomeScreen { get; set; }
        private object PuzzleScreen { get; set; }
        public Cell<object> CurrentScreen { get; private set; }

        internal class StartPuzzleCommand : ICommand
        {
            public StartPuzzleCommand(MainViewModel mvm)
            {
                this.mvm = mvm;
            }
            private MainViewModel mvm;

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this.mvm.CurrentScreen.Value = this.mvm.PuzzleScreen;
            }
        }
    }
}
