using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace UWPBook.P_Flash
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class P_Ball : Page
    {
        public P_Ball()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ball_animation.Begin();
            //ProductColor();
        }

        private void ProductColor()
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                sb.Append(r.Next(9));
            }
            ball.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
            
            
        }
    }
}
