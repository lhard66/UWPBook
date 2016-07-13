using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWPBook.P_Calculator_MVVM
{
    public class DivideCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            CalculatorViewModel vmodel = parameter as CalculatorViewModel;
            if (vmodel == null) return false;
            return vmodel.Num2 != 0;
        }

        public void Execute(object parameter)
        {
            CalculatorViewModel vmodel = parameter as CalculatorViewModel;
            if (vmodel == null) return;
            vmodel.Result = vmodel.Num1 / vmodel.Num2;
        }
    }
}
