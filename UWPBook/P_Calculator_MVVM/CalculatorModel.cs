using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPBook.P_Calculator_MVVM
{
    //这里模拟从数据库调出的数据
    public class CalculatorModel
    {
        public double num1 { get; set; }
        public double num2 { get; set; }
        public double result { get; set; }

        public DateTime ChangeTime { get; set; }
        public bool isDel { get; set; }
    }
}
