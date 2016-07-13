using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPBook.P_Calculator_MVVM;

namespace UWPBook.P_Calculator_MVVM
{
    public class CalculatorViewModel : BaseModel
    {
        public CalculatorViewModel()
        {
            //模拟数据库数据可以写在这里
            Command = new ClickCommand();
            DivideCommand = new DivideCommand();
            testProcessRing();


        }
        /// <summary>
        /// ProcessRing控件的演示
        /// </summary>
        private async void testProcessRing()
        {
            LoadStatus = true;
            await System.Threading.Tasks.Task.Delay(6000);
            LoadStatus = false;
        }
        public double Num1 { get; set; }
        private double _num2;

        public double Num2
        {
            get { return _num2; }
            set
            {
                _num2 = value;
                DivideCommand.OnCanExecuteChanged();

            }
        }

        private double _result;

        public ClickCommand Command { get; set; }
        public DivideCommand DivideCommand { get; set; }

        public double Result
        {
            get { return _result; }
            set
            {                
                SetProperty<double>(ref _result, value);
            }
        }

        private bool _loadStatus;
        public bool LoadStatus
        {
            get { return _loadStatus; }
            set
            {
                SetProperty<bool>(ref _loadStatus, value);
            }
        }

    }
}
