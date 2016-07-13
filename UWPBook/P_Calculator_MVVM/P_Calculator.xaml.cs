using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace UWPBook.P_Calculator_MVVM
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class P_Calculator : Page
    {
        public CalculatorViewModel viewModel { get; set; }
        public P_Calculator()
        {
            viewModel = new CalculatorViewModel();
            viewModel.Num1 = 1;
            viewModel.Num2 = 2;
            viewModel.Result = 3;
                                    
            this.InitializeComponent();
        }

       
    }
}
