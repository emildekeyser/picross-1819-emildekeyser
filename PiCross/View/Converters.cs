using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View
{
    public class SquareConverter : IValueConverter
    {
        public object Empty { get; set; }
        public object Filled { get; set; }
        public object Unknown { get; set; }

        //public object EmptySquare { get; set; }
        //public object FilledSquare { get; set; }
        //public object UnknownSquare { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (PiCross.Square)value;
            if (square == PiCross.Square.EMPTY)
                return Empty;
            if (square == PiCross.Square.FILLED)
                return Filled;
            else
                return Unknown;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { throw new NotImplementedException(); }
    }

    public class SolvedConverter : IValueConverter
    {
        public object Solved { get; set; }
        public object Unsolved { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var solved = (bool)value;
            if (solved)
                return Solved;
            else
                return Unsolved;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { throw new NotImplementedException();}
    }
}
