using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWPBook.P_Calculator_MVVM
{
    public class ClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CalculatorViewModel vmodel = parameter as CalculatorViewModel;
            if (vmodel == null) return;
            vmodel.Result = vmodel.Num1 + vmodel.Num2;
        }
    }
}
